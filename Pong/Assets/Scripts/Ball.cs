using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rig;
    public float startingSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bool isRight = UnityEngine.Random.value > 0.5f;
        float xVelocity = -1.0f;
        if (isRight == true)
        {
            xVelocity = 1.0f;
        }
        float yVelocity =  UnityEngine.Random.Range(-1.0f, 1.0f);
        rig.linearVelocity = new Vector2(xVelocity * startingSpeed, yVelocity * startingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
