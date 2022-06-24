using UnityEngine;

public class Move : MonoBehaviour
{
    #region Variables
    public bool useGameSpeed = true;
    public float speed = 20f;
    public Vector3 direction = Vector3.down;
    public bool onlyOnGamePlaying = true;
    
    Rigidbody2D rb;
    #endregion

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        speed = useGameSpeed ? GameSpeed.CurrentGameSpeed : speed;
    }

    void Update() {
        speed = useGameSpeed ? GameSpeed.CurrentGameSpeed : speed;
    }

    void FixedUpdate() {
        rb.velocity = direction * speed;
    }
}
