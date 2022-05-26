using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Spawner : MonoBehaviour
{
    #region Variables
    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;
    public List<GameObject> prefabs;

    float spawnCooldown = 2f;
    bool prefabsListNotEmpty;
    #endregion

    void Awake() {
        prefabsListNotEmpty = prefabs.Count > 0;
    }

    void Start() {
        SetRandomSpawnCooldown();
    }

    void Update() {
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0 && prefabsListNotEmpty) {
            // && GameController.IsPlaying) {
            SetRandomSpawnCooldown();
            SpawnRandomPrefab();
        }
    }

    void SpawnRandomPrefab() {
        GameObject rndPrefab = prefabs[Random.Range(0, prefabs.Count)];
        Vector3 pos = transform.position;
        pos.y = rndPrefab.transform.position.y;
        Instantiate(rndPrefab, pos, rndPrefab.transform.rotation, transform);
    }

    void SetRandomSpawnCooldown() {
        spawnCooldown = Random.Range(minSpawnRate, maxSpawnRate);
    }
}
