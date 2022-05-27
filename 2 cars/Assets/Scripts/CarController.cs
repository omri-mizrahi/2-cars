using UnityEngine;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    #region Variables
    [Range(0, 100)] public float touchRangeMin; 
    [Range(0, 100)] public float touchRangeMax;
    public float rotateAngle = 15f;
    public float lerpDuration = .2f;

    public List<float> laneXPositions;

    float lerpRatio;
    Vector2 lerpStartPos;
    Vector2 lerpTarget;
    bool shouldSwitchLane;
    int currLane;
    float worldToScreenMultiplier;
    float percentToWorldMultiplier;
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
        lerpStartPos = lerpTarget = transform.position;
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
        transform.position = Vector2.Lerp(lerpStartPos, lerpTarget, lerpRatio);
    }

    void FixedUpdate() {
        if (shouldSwitchLane) {
            SwitchLane();
            shouldSwitchLane = false;
        }
    }

    // TODO: handle collisions with obstacles and collectibles

    void SwitchLane() {
        int dstLane = 1 - currLane;
        CancelInvoke();
        RotateCar(dstLane);
        Vector2 dstPos = new Vector2(laneXPositions[dstLane], transform.position.y);
        SetDestination(dstPos);
        currLane = dstLane;
        Invoke(nameof(ResetCarRotate), lerpDuration);
    }


    void SetDestination(Vector2 destination)
     {
        lerpRatio = 0;
        lerpStartPos = transform.position;
        lerpTarget = destination;
     }

     void RotateCar(int dstLane) {
         int angleMultiplier = 1 - (dstLane * 2);  // determine wether to rotate a positive or a negetive angle, by dst lane
         transform.Rotate(Vector3.forward, rotateAngle * angleMultiplier);
     }

     void ResetCarRotate() {
         transform.rotation = Quaternion.identity;
     }
}
