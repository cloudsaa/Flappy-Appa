using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float jumpForce = 50f;

    [SerializeField]
    Transform startPosition;

    bool gameStarted = false;
    private Vector3 initialPosition;

    private Rigidbody2D rb;

    public GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    public void StartGame()
    {
        rb.gravityScale = 1f;
        gameStarted = true;
    }

    void Update()
    {
        if (gameStarted && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.linearVelocity = new Vector2(0f, jumpForce);
        }
    }

    public void GameOver()
    {
        gameStarted = false;
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Pipe") ||
            collision.gameObject.CompareTag("Ground"))
        {
            gameManager.GameOver();
        }
    }

    public void ResetPlayer()
    {
        transform.position = startPosition.position;
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 1f;
        gameStarted = true;
        gameManager.StartGame();
    }
}