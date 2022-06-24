using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    #region Variables
    public static float CurrentGameSpeed;
    public float StartingSpeed = 20f;
    public float AccelerationOverTime = 1f;
    #endregion

    void Awake() {
        // var defaultValues = Config.DefaultSettings[GameMode.CurrentGameMode];
        // StartingSpeed = PlayerPrefs.GetFloat(GameMode.CurrentGameMode + Consts.Settings.StartingSpeed, 
        //                                         defaultValues[Consts.Settings.StartingSpeed]);
        // AccelerationOverTime = PlayerPrefs.GetFloat(GameMode.CurrentGameMode + Consts.Settings.GameAcceleration, 
        //                                         defaultValues[Consts.Settings.GameAcceleration]);
    }

    void Update() {
        if (GameController.IsPlaying) {
            CurrentGameSpeed += AccelerationOverTime * Time.deltaTime;
        }
    }
}
