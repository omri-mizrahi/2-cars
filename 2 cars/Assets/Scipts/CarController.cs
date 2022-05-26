using UnityEngine;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    #region Variables
    [Range(0, 100)]
    public float touchRangeMin; public float touchRangeMax;

    bool shouldSwitchLane;
    int currLane;
    List<Vector2> lanePositions;

    public float lerpDuration = 1;
    float lerpRatio;
    Vector2 lerpStartPos;
    Vector2 lerpTarget;
    #endregion

    void Awake()
    {
        shouldSwitchLane = false;
        currLane = 0;
        float touchWidth = touchRangeMax - touchRangeMin;
        Vector2 leftLanePos = new Vector2(touchRangeMin + touchWidth / 4, transform.position.y);
        Vector2 rightLanePos = leftLanePos;
        rightLanePos.x = touchRangeMax - touchWidth / 4;
        lanePositions = new List<Vector2>{leftLanePos, rightLanePos};
    }

    void Update()
    {
        foreach (Touch touch in Input.touches) {
            float touchPosX = touch.position.x;
            if (touchPosX >= touchRangeMin && touchPosX <= touchRangeMax) {
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

    void SwitchLane() {
        int dstLane = 1 - currLane;
        Vector2 dstPos = lanePositions[dstLane];
        RotateCar(dstLane);
        SetDestination(dstPos);
        currLane = dstLane;
    }


    void SetDestination(Vector2 destination)
     {
        lerpRatio = 0;
        lerpStartPos = transform.position;
        lerpTarget = destination;
     }

     void RotateCar(int dstLane) {
         transform.Rotate()
     }
}
