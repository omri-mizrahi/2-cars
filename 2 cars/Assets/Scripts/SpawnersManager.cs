using UnityEngine;

public class SpawnersManager : MonoBehaviour
{
    #region Variables
    public static float StartSpawnRate;
    public static float AccelerationOverTime;
    public static float MinSpawnRate;

    // Editable from editor:
    public float startSpawnRate = 1f;
    public float accelerationOverTime = .01f;
    public float minSpawnRate = .6f;
    #endregion

    void Awake() {
        StartSpawnRate = startSpawnRate;
        AccelerationOverTime = accelerationOverTime;
        MinSpawnRate = minSpawnRate;
    }
}
