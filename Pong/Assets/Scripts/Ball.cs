using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rig;
    public float speed = 7.0f;
    
    void Start()
    {
        LaunchBall();
    }
    void LaunchBall()
    {
        float x = Random.value > 0.5 ? 1.0f : -1.0f;
        float y = Random.Range(-0.9f, 0.9f);
        Vector2 dir = new Vector2(x, y).normalized;
        rig.linearVelocity = dir * speed;
    }
    void FixedUpdate()
    {
        rig.linearVelocity = rig.linearVelocity.normalized * speed;
    }
    public void ResetBall(Vector2 position)
    {
        rig.linearVelocity = Vector2.zero;
        rig.angularVelocity = 0.0f;
        
        rig.position = position;

        StartCoroutine(RestartAfterDelay(1.0f));
    }
    private System.Collections.IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        LaunchBall();
    }
}
