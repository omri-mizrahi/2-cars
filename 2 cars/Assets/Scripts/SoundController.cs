using UnityEngine;

public class SoundController : MonoBehaviour
{
    #region Variables
    public AudioClip CollectSound;
    public AudioClip ObstacleSound;
    public AudioClip BackgroundMusic;
    
    static AudioClip collectSound;
    static AudioClip obstacleSound;
    static AudioSource audioSource;
    #endregion

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        collectSound = CollectSound;
        obstacleSound = ObstacleSound;
    }

    void Start() {
        if (BackgroundMusic) {
            audioSource.clip = BackgroundMusic;
            audioSource.Play();
        }
    }

    public static void PlayCollectSound() {
        audioSource.PlayOneShot(collectSound);
    }

    public static void PlayObstacleSound() {
        audioSource.PlayOneShot(obstacleSound);
    }
}
