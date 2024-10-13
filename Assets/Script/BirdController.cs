using System.Collections;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float jumpForce = 5f;
    public float jumpCooldown = 1.5f;
    private bool canJump = true;
    private Rigidbody2D rb;
    private int score = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && canJump)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        StartCoroutine(JumpCooldownCoroutine());
    }

    private IEnumerator JumpCooldownCoroutine()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }
    private void PlayerLose()
    {
        Time.timeScale = 0; // Stop time to end the game
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            PlayerLose(); // Handle game over logic when hitting an obstacle
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score"))
        {
            AddScore();
        }
    }

    public void AddScore()
    {
        score++;
        Debug.Log("Score: " + score);

        if (score == 6)
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static;
            DragonSummonEvent.TriggerDragonSummon();
        }
    }
}