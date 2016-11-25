using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour {

    protected GameObject healthBar;
    protected GameObject energyBar;
    protected GameObject textStatus;

    private const float barWidth = 1.0f;
    private const float barHeight = 0.1f;
    private const float barOffset = 0.2f; // distance between the bars

    public float health = 100.0f;
    public float energy = 100.0f;
    protected float linearSpeed = 5.0f; // units per second
    protected float angularSpeed = 180.0f; // degrees per second
    protected const float energyDecay = 1.0f; // per second

    public int attackDamage = 10;
    public float attackRadius = 5.0f;
    protected const float attackCooldown = 2.0f;
    protected float attackDelay = 3.0f;
    private const float takeDamgeColorFlash = 0.5f;
    private float damageFlashDelay = 0.0f;
    private Color defaultColor;

    protected virtual void Start () {
        //GetComponent<Rigidbody>().isKinematic = true;
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

        textStatus.transform.position = new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z - 1.0f);
        textStatus.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

        UpdateUI();
        DrainEnergy();
    }

   protected virtual void UpdateUI () {
        healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(health / 100 * barWidth, barHeight);
        energyBar.GetComponent<RectTransform>().sizeDelta = new Vector2(energy / 100 * barWidth, barHeight);
    }

    protected virtual void DrainEnergy() {
        if (energy <= 0) return;
        energy -= energyDecay * Time.deltaTime;
        UpdateUI();
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
        transform.LookAt(new Vector3(location.x, 1, location.z));
        transform.Translate(Vector3.forward * linearSpeed * Time.deltaTime);
    }

    public virtual void AttackForward() {
        if (attackDelay >= 0) return;
        attackDelay = attackCooldown;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRadius);
        {
            for(int i = 0; i < hitColliders.Length; ++i)
            {
                PlayerController c = hitColliders[i].GetComponent<PlayerController>();
                if(c != null && c != this)
                {
                    if(c.health <= health)
                        c.TakeDamage(attackDamage);
                }
            }            
        }
    }

    public void TakeDamage(int amount) {
        GetComponent<Renderer>().material.color = Color.red;
        damageFlashDelay = takeDamgeColorFlash;
        health -= amount;
        UpdateUI();
    }

    public virtual void ChangeStatus(string s) {
        textStatus.GetComponent<Text>().text = s;
    }

}
