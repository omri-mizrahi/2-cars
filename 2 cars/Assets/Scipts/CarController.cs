using UnityEngine;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    #region Variables
    [Range(0, 100)] public float touchRangeMin; 
    [Range(0, 100)] public float touchRangeMax;

    bool shouldSwitchLane;
    int currLane;
    List<Vector2> lanePositions;
    float worldToScreenMultiplier;
    float percentToWorldMultiplier;

    public float rotateAngle = 15f;
    public float lerpDuration = .2f;
    float lerpRatio;
    Vector2 lerpStartPos;
    Vector2 lerpTarget;
    #endregion

    void Awake()
    {
        print(Camera.main.orthographicSize);
        shouldSwitchLane = false;
        currLane = 0;
        worldToScreenMultiplier = Screen.width / 100;
        percentToWorldMultiplier = Camera.main.orthographicSize / 100;
        float touchWidth = touchRangeMax - touchRangeMin;
        float leftLaneX = (touchRangeMin + touchWidth / 4) * percentToWorldMultiplier;
        Vector2 leftLanePos = new Vector2(leftLaneX, transform.position.y);
        float rightLaneX = (touchRangeMax - touchWidth / 4) * percentToWorldMultiplier;
        Vector2 rightLanePos = new Vector2(rightLaneX, transform.position.y);
        lanePositions = new List<Vector2>{leftLanePos, rightLanePos};        
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

    void SwitchLane() {
        int dstLane = 1 - currLane;
        Vector2 dstPos = lanePositions[dstLane];
        CancelInvoke();
        RotateCar(dstLane);
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
