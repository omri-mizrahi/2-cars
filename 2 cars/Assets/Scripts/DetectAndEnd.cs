using UnityEngine;

public class DetectAndEnd : MonoBehaviour
{
    #region Variables
    public float repeatRate = .5f;
    public string detectTag = "Obstacle";
    
    GameObject detectedObj;
    bool detected = false;
    #endregion


    void Blink() {
        detectedObj.SetActive(!detectedObj.activeInHierarchy);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(detectTag) && !detected) {
            detected = true;
            GameController.EndGame();
            detectedObj = other.gameObject;
            InvokeRepeating(nameof(Blink), 0, repeatRate);
        }
    }
}
