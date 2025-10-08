using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    [Header("Configurações")]
    public Rigidbody2D rig;
    public float speed = 7.0f;
    public float restartDelay = 0.5f;

    [Header("Pontuação")] 
    public int playerOcidentalScore = 0;
    public int playerOrientalScore = 0;
    public TextMeshProUGUI scoreText;
    
    private bool isRestarting = false;
    
    void Start()
    {
        LaunchBall();
        UpdateScoreUI();
    }
    void LaunchBall()
    {
        float x = Random.value > 0.5 ? 1.0f : -1.0f;
        float y = Random.Range(-0.7f, 0.7f);
        Vector2 dir = new Vector2(x, y).normalized;
        
        rig.linearVelocity = dir * speed;
        isRestarting = false;
    }
    void FixedUpdate()
    {
        if (!isRestarting && rig.linearVelocity.sqrMagnitude > 0.01)
        {
            rig.linearVelocity = rig.linearVelocity.normalized * speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isRestarting)
            {
                if (collision.gameObject.name.Contains("PlayerOcidental"))
                {
                    playerOcidentalScore++;
                }
                if (collision.gameObject.name.Contains("PlayerOriental"))
                {
                    playerOrientalScore++;
                }
                UpdateScoreUI();
                ResetBall(Vector2.zero);
            }
        }
    }
    public void ResetBall(Vector2 position)
    {
        if (isRestarting) return;
        isRestarting = true;
        
        rig.linearVelocity = Vector2.zero;
        rig.angularVelocity = 0.0f;
        rig.position = position;

        StartCoroutine(RestartAfterDelay(restartDelay));
    }
    private System.Collections.IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        LaunchBall();
    }
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"P1: {playerOcidentalScore}   P2: {playerOrientalScore}";
        }
    }
}
