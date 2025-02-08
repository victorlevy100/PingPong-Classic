using UnityEngine;

public class EnemyPaddleController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public Vector2 limits = new Vector2(-4f, 4f);

    private GameObject ball;
    private Rigidbody2D ballRb;

    public bool isPlayer1 = true;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball");
        if (ball != null)
        {
            ballRb = ball.GetComponent<Rigidbody2D>();
        }

        if (isPlayer1)
        {
            spriteRenderer.color = SaveController.GetInstance().colorPlayer;
        }
        else
        {
            spriteRenderer.color = SaveController.GetInstance().colorEnemy;
        }
    }

    void Update()
    {
        if (ball != null && ballRb != null)
        {
            // Prever a posição futura da bola
            Vector2 ballPosition = ball.transform.position;
            Vector2 ballVelocity = ballRb.linearVelocity;
            float timeToReachPaddle = (transform.position.x - ballPosition.x) / ballVelocity.x;
            float predictedY = ballPosition.y + ballVelocity.y * timeToReachPaddle;

            // Limitar a posição prevista aos limites da tela
            float targetY = Mathf.Clamp(predictedY, limits.x, limits.y);
            Vector2 targetPosition = new Vector2(transform.position.x, targetY);

            // Mover o paddle em direção à posição prevista
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}