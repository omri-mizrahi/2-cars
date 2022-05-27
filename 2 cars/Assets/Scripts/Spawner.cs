using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    #region Variables
    public float startDelay = .75f;
    public List<GameObject> prefabs;
    public CarController carController;

    List<float> laneXPositions;
    float spawnRate;
    float spawnCooldown;
    bool prefabsListNotEmpty;
    #endregion

    void Awake() {
        prefabsListNotEmpty = prefabs.Count > 0;
    }

    void Start() {
        laneXPositions = carController.laneXPositions;
        spawnRate = SpawnersManager.StartSpawnRate;
        SetSpawnCooldown();
        spawnCooldown += startDelay;
    }

    void Update() {
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0 && prefabsListNotEmpty && GameController.IsPlaying) {
            SetSpawnCooldown();
            SpawnRandomPrefabRandomLane();
        }
        if (spawnRate > SpawnersManager.MinSpawnRate) {
            spawnRate -= SpawnersManager.AccelerationOverTime * Time.deltaTime;
        }
    }

    void SpawnRandomPrefabRandomLane() {
        GameObject rndPrefab = prefabs[Random.Range(0, prefabs.Count)];
        float rndLaneX = laneXPositions[Random.Range(0, laneXPositions.Count)];
        Vector2 pos = new Vector2(rndLaneX, transform.position.y);
        Instantiate(rndPrefab, pos, rndPrefab.transform.rotation, transform);
    }

    void SetSpawnCooldown() {
        spawnCooldown = spawnRate;
    }
}
