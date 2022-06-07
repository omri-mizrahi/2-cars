using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(GameSpeed), typeof(AudioSource))]
public class GameController : MonoBehaviour
{
    #region Variables
    public enum GameMode {Pregame, Playing, Gameover};
    public static GameMode CurrGameMode;
    GameSpeed gameSpeed;
    #endregion

    void Awake() {
        gameSpeed = GetComponent<GameSpeed>();
    }

    void Start() {
        CurrGameMode = GameMode.Pregame;
        StartGame();
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Fire1")) {
            switch (CurrGameMode) {
                case GameMode.Pregame:
                    StartGame();
                    break;
                case GameMode.Gameover:
                    GameOverMenu();
                    break;
            }
        }
        if (CurrGameMode == GameMode.Gameover) {
            Invoke(nameof(GameOverMenu), 1.5f);
        }
    }

    void StartGame() {
        GameSpeed.CurrentGameSpeed = gameSpeed.startingSpeed;
        CurrGameMode = GameMode.Playing;
    }
    
    public static void EndGame() {
        GameSpeed.CurrentGameSpeed = 0;
        CurrGameMode = GameMode.Gameover;
    }

    void GameOverMenu() {
        SceneManager.LoadScene(Consts.Scenes.GameOverMenu);
    }

    public static bool IsPlaying => CurrGameMode == GameMode.Playing;
}
