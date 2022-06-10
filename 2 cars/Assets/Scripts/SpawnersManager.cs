using UnityEngine;

public class SpawnersManager : MonoBehaviour
{
    #region Variables
    public static float StartSpawnRate;
    public static float AccelerationOverTime;
    public static float MinSpawnRate;
    #endregion

    void Awake() {
        var defaultValues = Consts.DefaultSettings[GameMode.CurrentGameMode];
        StartSpawnRate = PlayerPrefs.GetFloat(GameMode.CurrentGameMode + Consts.Settings.StartSpawnRate, 
                                                defaultValues[Consts.Settings.StartSpawnRate]);
        AccelerationOverTime = PlayerPrefs.GetFloat(GameMode.CurrentGameMode + Consts.Settings.SpawnAcceleration, 
                                                defaultValues[Consts.Settings.SpawnAcceleration]);
        MinSpawnRate = PlayerPrefs.GetFloat(GameMode.CurrentGameMode + Consts.Settings.MinSpawnRate, 
                                                defaultValues[Consts.Settings.MinSpawnRate]);
    }
}
