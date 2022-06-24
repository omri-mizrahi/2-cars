using UnityEngine;

public class SpawnersManager : MonoBehaviour
{
    #region Variables
    public static float StartSpawnRate;
    public static float AccelerationOverTime;
    public static float MinSpawnRate;

    public float startSpawnRate = 1f;
    public float accelerationOverTime = .01f;
    public float minSpawnRate = .6f;
    #endregion

    void Awake() {
        // var defaultValues = Config.DefaultSettings[GameMode.CurrentGameMode];
        // StartSpawnRate = PlayerPrefs.GetFloat(GameMode.CurrentGameMode + Consts.Settings.StartSpawnRate, 
        //                                         defaultValues[Consts.Settings.StartSpawnRate]);
        // AccelerationOverTime = PlayerPrefs.GetFloat(GameMode.CurrentGameMode + Consts.Settings.SpawnAcceleration, 
        //                                         defaultValues[Consts.Settings.SpawnAcceleration]);
        // MinSpawnRate = PlayerPrefs.GetFloat(GameMode.CurrentGameMode + Consts.Settings.MinSpawnRate, 
        //                                         defaultValues[Consts.Settings.MinSpawnRate]);

        StartSpawnRate = startSpawnRate;
        AccelerationOverTime = accelerationOverTime;
        MinSpawnRate = minSpawnRate;
    }
}
