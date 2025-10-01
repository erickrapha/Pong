using UnityEngine;

public class PlayerControlador : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public Vector2 minBounds;
    public Vector2 maxBounds;
    public bool isPlayerOne = true;
    
    private Rigidbody2D rig;
    
    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.bodyType = RigidbodyType2D.Kinematic;
    }
    void FixedUpdate()
    {
        float input = 0.0f;

        if (isPlayerOne)
        {
            if (Input.GetKey(KeyCode.W)) input = 1.0f;
            else if (Input.GetKey(KeyCode.S)) input = -1.0f;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow)) input = 1.0f;
            else if (Input.GetKey(KeyCode.DownArrow)) input = -1.0f;
        }
        Vector2 pos = rig.position;
        pos.y += input * moveSpeed * Time.fixedDeltaTime;
        
        pos.y = Mathf.Clamp(pos.y, minBounds.y, maxBounds.y);
        
        rig.MovePosition(pos);
        
    }
}
