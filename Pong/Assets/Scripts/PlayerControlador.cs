using UnityEngine;

public class PlayerControlador : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 minBounds;
    public Vector2 maxBounds;
    public bool isPlayerOne = true;
    
    private Rigidbody2D rig;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
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
        Vector2 velocity = new Vector2(0, input * moveSpeed);
        rig.linearVelocity = velocity;
        
        Vector2 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minBounds.y, maxBounds.y);
        transform.position = pos;
        
    }
}
