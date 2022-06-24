using UnityEngine;

public class DetectAndEnd : MonoBehaviour
{
    #region Variables
    public float repeatRate = .5f;
    public string detectTag = "Obstacle";
    
    Renderer detectedObjRndr;
    bool detected = false;
    #endregion


    void Blink() {
        detectedObjRndr.enabled = !detectedObjRndr.enabled;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(detectTag) && !detected) {
            detected = true;
            GameController.EndGame();
            SoundController.PlayObstacleSound();
            detectedObjRndr = other.gameObject.GetComponent<Renderer>();
            InvokeRepeating(nameof(Blink), 0, repeatRate);
        }
    }
}
