using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rig;
    public float startingSpeed = 5.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LaunchBall();
    }
    void LaunchBall()
    {
        float x = Random.value > 0.5 ? 1.0f : -1.0f;
        float y = Random.Range(-0.7f, 0.7f);
        Vector2 dir = new Vector2(x, y).normalized;
        rig.linearVelocity = dir * startingSpeed;
    }
    public void ResetBall(Vector2 position)
    {
        transform.position = position;
        rig.linearVelocity = Vector2.zero;
        Invoke(nameof(LaunchBall), 1.0f);
    }
}
