using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    #region Variables
    public static float CurrentGameSpeed;
    public float StartingSpeed = 20f;
    float accelerationOverTime = 1f;
    #endregion

    void Awake() {
        var defaultValues = Config.DefaultSettings[GameMode.CurrentGameMode];
        StartingSpeed = PlayerPrefs.GetFloat(GameMode.CurrentGameMode + Consts.Settings.StartingSpeed, 
                                                defaultValues[Consts.Settings.StartingSpeed]);
        accelerationOverTime = PlayerPrefs.GetFloat(GameMode.CurrentGameMode + Consts.Settings.GameAcceleration, 
                                                defaultValues[Consts.Settings.GameAcceleration]);
    }

    void Update() {
        if (GameController.IsPlaying) {
            CurrentGameSpeed += accelerationOverTime * Time.deltaTime;
        }
    }
}
