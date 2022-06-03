using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(DetectAndEnd))]
public class CarController : MonoBehaviour
{
    #region Variables
    [Range(0, 100)] public float touchRangeMin; 
    [Range(0, 100)] public float touchRangeMax;
    public float rotateAngle = 15f;
    public float lerpDuration = .2f;

    [System.NonSerialized]
    public List<float> laneXPositions;

    float lerpRatio;
    Vector2 lerpStartPos;
    Vector2 lerpTarget;
    bool shouldSwitchLane;
    int currLane;
    float worldToScreenMultiplier;
    float percentToWorldMultiplier;
    bool moving;
    #endregion

    void Awake()
    {
        shouldSwitchLane = false;
        currLane = 0;
        worldToScreenMultiplier = Screen.width / 100;
        percentToWorldMultiplier = Camera.main.orthographicSize / 100;
        float touchWidth = touchRangeMax - touchRangeMin;
        float leftLaneX = (touchRangeMin + touchWidth / 4) * percentToWorldMultiplier;
        float rightLaneX = (touchRangeMax - touchWidth / 4) * percentToWorldMultiplier;
        laneXPositions = new List<float>{leftLaneX, rightLaneX};
    }
    
    void Start() {
        transform.position = new Vector2(laneXPositions[0], transform.position.y);
        lerpStartPos = lerpTarget = transform.position;
        Debug.Log($"{gameObject.name}'s position is: ${lerpStartPos}");
    }

    void Update()
    {
        foreach (Touch touch in Input.touches) {
            float touchPosX = touch.position.x;
            if (touch.phase == TouchPhase.Began &&
                touchPosX >= touchRangeMin * worldToScreenMultiplier && touchPosX <= touchRangeMax * worldToScreenMultiplier) {
                shouldSwitchLane = true;
            }
        }
        lerpRatio += Time.deltaTime / lerpDuration;
        if (moving) {
            transform.position = Vector2.Lerp(lerpStartPos, lerpTarget, lerpRatio);
        }
    }

    void FixedUpdate() {
        if (shouldSwitchLane) {
            SwitchLane();
            shouldSwitchLane = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(Consts.CollectibleTag)) {
            Destroy(other.gameObject);
            GameScore.CurrentGameScore += 1;
            SoundController.PlayCollectSound();
        }
    }
    

    void SwitchLane() {
        int dstLane = 1 - currLane;
        CancelInvoke();
        RotateCar(dstLane);
        Vector2 dstPos = new Vector2(laneXPositions[dstLane], transform.position.y);
        SetDestination(dstPos);
        currLane = dstLane;
        Invoke(nameof(StopMoving), lerpDuration);
    }


    void SetDestination(Vector2 destination)
     {
        moving = true;
        lerpRatio = 0;
        lerpStartPos = transform.position;
        lerpTarget = destination;
     }

     void RotateCar(int dstLane) {
         int angleMultiplier = 1 - (dstLane * 2);  // determine wether to rotate a positive or a negetive angle, by dst lane
         transform.Rotate(Vector3.forward, rotateAngle * angleMultiplier);
     }

     void StopMoving() {
         transform.rotation = Quaternion.identity;
         moving = false;
     }
}
