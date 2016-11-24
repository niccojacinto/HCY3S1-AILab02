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
    public static Vector3 levelPosition;

    public static List<Character> allCharacters;
    public static List<Pickup> allPickups;

    public float numEnemies = 3;

    void Start() {

        // Initialize Lists
        allCharacters = new List<Character>();
        allPickups = new List<Pickup>();

        // Set Level Bounds based on mesh size
        levelWidth = GetComponent<Renderer>().bounds.size.x;
        levelHeight = GetComponent<Renderer>().bounds.size.z;
        levelPosition = transform.position;

        // Instantiate Player
        GameObject player = Instantiate(playerPrefab, GetRandomLocation(), Quaternion.identity) as GameObject;
        allCharacters.Add(player.GetComponent<Character>());

        // Instantiate All Enemies
        for (int i=0; i<numEnemies; ++i) {
            GameObject enemy = Instantiate(aiPrefab, GetRandomLocation(), Quaternion.identity) as GameObject;
            allCharacters.Add(enemy.GetComponent<Character>());
        }
    }
	
	void Update () {
        
    }

    void FixedUpdate() {
        CheckIntegrity();

        if (HealthPack.numHealthPacks < 5) {
            SpawnPickup(healthPackPrefab, GetRandomLocation());
            HealthPack.numHealthPacks++;
        }

        if (EnergyPill.numEnergyPills < 5) {
            SpawnPickup(energyPillPrefab, GetRandomLocation());
            EnergyPill.numEnergyPills++;
        }
    }

    // Helper: Returns a random location within the arena bounds
    public Vector3 GetRandomLocation() {
        float x = Random.Range(transform.position.x - levelWidth/2, transform.position.x + levelWidth/2);
        float z = Random.Range(transform.position.z - levelHeight/2, transform.position.z + levelHeight/2);
        float y = transform.position.y + 1.0f;

        return new Vector3(x, y, z);
    }

    public static Vector3 SGetRandomLocation() {
        float x = Random.Range(levelPosition.x - levelWidth / 2, levelPosition.x + levelWidth / 2);
        float z = Random.Range(levelPosition.z - levelHeight / 2, levelPosition.z + levelHeight / 2);
        float y = levelPosition.y + 1.0f;

        return new Vector3(x, y, z);
    }

    private static bool PointIsOutsideLevel(Vector3 v3) {

        if (v3.x < levelPosition.x - levelWidth / 2 ||
             v3.x > levelPosition.x + levelWidth / 2 ||
             v3.z < levelPosition.z - levelHeight / 2 ||
             v3.z > levelPosition.z + levelHeight / 2)
            return true;

        return false;
    }

    // Helper: Spawns @param spawnable at given location
    void SpawnPickup(GameObject spawnable, Vector3 location) {
        GameObject p = Instantiate(spawnable, location, Quaternion.identity) as GameObject;
        allPickups.Add(p.GetComponent<Pickup>());
    }

    // Checks wether all characters are supposed to be dead and changes their state if they are
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
