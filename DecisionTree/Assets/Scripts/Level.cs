using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

    public GameObject playerPrefab;
    public GameObject aiPrefab;
    public GameObject healthPackPrefab;
    public GameObject energyPillPrefab;

    public static float levelWidth;
    public static float levelHeight;

    public static List<Character> allCharacters;
    public static PlayerController playerRef;
    public static List<Pickup> allPickups;

    private float numEnemies = 3;

    void Start() {
        allCharacters = new List<Character>();
        allPickups = new List<Pickup>();

        levelWidth = GetComponent<Renderer>().bounds.size.x;
        levelHeight = GetComponent<Renderer>().bounds.size.z;

        GameObject player = Instantiate(playerPrefab, GetRandomLocation(), Quaternion.identity) as GameObject;
        allCharacters.Add(player.GetComponent<Character>());
        playerRef = player.GetComponent<PlayerController>();

        Debug.Log("player spawned");
        for (int i=0; i<numEnemies; ++i) {
            GameObject enemy = Instantiate(aiPrefab, GetRandomLocation(), Quaternion.identity) as GameObject;
            allCharacters.Add(enemy.GetComponent<Character>());
        }
    }
	
	void Update () {
        CheckIntegrity();
    }

    void FixedUpdate() {
        if (HealthPack.numHealthPacks < 5) {
            SpawnPickup(healthPackPrefab, GetRandomLocation());
            HealthPack.numHealthPacks++;
        }

        if (EnergyPill.numEnergyPills < 5) {
            SpawnPickup(energyPillPrefab, GetRandomLocation());
            EnergyPill.numEnergyPills++;
        }
    }

    Vector3 GetRandomLocation() {
        float x = Random.Range(transform.position.x - levelWidth/2, transform.position.x + levelWidth/2);
        float z = Random.Range(transform.position.z - levelHeight/2, transform.position.z + levelHeight/2);
        float y = transform.position.y + 1.0f;

        return new Vector3(x, y, z);
    }

    void SpawnPickup(GameObject spawnable, Vector3 location) {
        GameObject p = Instantiate(spawnable, location, Quaternion.identity) as GameObject;
        allPickups.Add(p.GetComponent<Pickup>());
    }

    void CheckIntegrity() {
        foreach (Character c in allCharacters) {
            if (c.health <= 0) {
                c.health = 100.0f;
                c.energy = 100.0f;
                c.transform.position = new Vector3(transform.position.x, transform.position.y+1.0f, transform.position.z);
            }
        }
    }
}
