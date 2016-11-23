using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour {

    private GameObject healthBar;
    private GameObject energyBar;
    private GameObject textStatus;

    private const float barWidth = 1.0f;
    private const float barHeight = 0.1f;
    private const float barOffset = 0.2f; // distance between the bars

    public float health = 100.0f;
    public float energy = 100.0f;
    public float linearSpeed = 10.0f; // units per second
    public float angularSpeed = 180.0f; // degrees per second .. currently only for player

    public const float energyDecay = 5.0f; // per second

    public const float attackCooldown = 0.5f;
    private float attackDelay = 0.0f;
    public const float takeDamgeColorFlash = 0.5f;
    private float damageFlashDelay = 0.0f;
    private Color defaultColor;

    protected virtual void Start () {
        GetComponent<Rigidbody>().isKinematic = true;
        defaultColor = GetComponent<Renderer>().material.color;

        Object healthBarObject = Resources.Load<GameObject>("HealthBar");
        healthBar = Instantiate(healthBarObject, GameObject.Find("Canvas").transform, false) as GameObject;

        Object  energyBarObject = Resources.Load<GameObject>("EnergyBar");
        energyBar = Instantiate(energyBarObject, GameObject.Find("Canvas").transform, false) as GameObject;

        Object textObject = Resources.Load<GameObject>("Text");
        textStatus = Instantiate(textObject, GameObject.Find("Canvas").transform, false) as GameObject;
    }

    protected virtual void Update() {
     
        attackDelay -= Time.deltaTime;
        damageFlashDelay -= Time.deltaTime;
        if (damageFlashDelay <= 0) {
            GetComponent<Renderer>().material.color = defaultColor;
        }

        healthBar.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.2f);
        healthBar.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);

        energyBar.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.0f);
        energyBar.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);

        textStatus.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.0f);
        textStatus.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

        UpdateUI();
        DrainEnergy();
    }

   private void UpdateUI () {
        healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(health / 100 * barWidth, barHeight);
        energyBar.GetComponent<RectTransform>().sizeDelta = new Vector2(energy / 100 * barWidth, barHeight);
    }

    protected virtual void DrainEnergy() {
        if (energy <= 0) return;
        energy -= energyDecay * Time.deltaTime;
        UpdateUI();
    }

    public virtual bool IsHealthy() {
        return health >= 50;
    }

    public virtual bool IsHyper() {
        return energy >= 50;
    }

    void OnTriggerEnter(Collider other) {
        other.GetComponent<Pickup>().OnPickup(this);
    }


    public void AddHealth(float amount) {
        health += amount;
        if (health > 100) health = 100;
    }

    public void AddEnergy(float amount) {
        energy += amount;
        if (energy > 100) energy = 100;
    }

    public void MoveTo(Vector3 location) {
        transform.LookAt(location);
        transform.Translate(Vector3.forward * linearSpeed * Time.deltaTime);
    }

    public void AttackForward() {
        if (attackDelay >= 0) return;
        attackDelay = attackCooldown;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward * 2.0f, out hit)) {
            Character c = hit.collider.GetComponent<Character>();
            if (c != null) {
                c.TakeDamage(10);
            }
        }
    }

    public void TakeDamage(int amount) {
        GetComponent<Renderer>().material.color = Color.red;
        damageFlashDelay = takeDamgeColorFlash;
        health -= amount;
        UpdateUI();
    }

    public virtual void ChangeState(Action action) {

    }

    public virtual void ChangeStatus(string s) {
        textStatus.GetComponent<Text>().text = s;
    }

    public bool IsStrongerThan(Character other) {
        if ((health + energy) > (other.health + other.energy))
            return true;
        return false;
    }

    public Character GetNearestCharacter() {
        Character nearestCharacter = null;
        float nearestDistance = 9999.0f;
        foreach (Character c in Level.allCharacters) {
            if (c == this) continue;
            float currentDistance = Vector3.Distance(transform.position, c.transform.position);
            if (currentDistance < nearestDistance) {
                nearestCharacter = c;
                nearestDistance = currentDistance;
            }
        }
        return nearestCharacter;
    }

    public float DistanceToNearestCharacter() {
        return Vector3.Distance(transform.position, GetNearestCharacter().transform.position);
    }

}
