using UnityEngine;

public class PlayerOcidental : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 minBounds;
    public Vector2 maxBounds;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minBounds.y, maxBounds.y);
        transform.position = pos;
        
        bool isPressingUp = Input.GetKey(KeyCode.W);
        bool isPressingDown = Input.GetKey(KeyCode.S);
        
        if (isPressingUp)
        {
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
        }
        if (isPressingDown)
        {
            transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
        }
    }
}
