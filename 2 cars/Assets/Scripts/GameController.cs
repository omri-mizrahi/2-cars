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
    public AudioClip ingameMusic;
    
    GameSpeed gameSpeed;
    AudioSource audioSource;

    private delegate void Action();
    #endregion

    void Awake() {
        audioSource = GetComponent<AudioSource>();
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
                    ResetGame();
                    break;
            }
        }
    }

    void StartGame() {
        GameSpeed.CurrentGameSpeed = gameSpeed.startingSpeed;
        CurrGameMode = GameMode.Playing;
        if (ingameMusic) {
            audioSource.clip = ingameMusic;
            audioSource.Play();
        }
    }
    
    public static void EndGame() {
        GameSpeed.CurrentGameSpeed = 0;
        CurrGameMode = GameMode.Gameover;
    }

    void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static bool IsPlaying => CurrGameMode == GameMode.Playing;
}
