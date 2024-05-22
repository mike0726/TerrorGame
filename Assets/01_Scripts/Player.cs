using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 3f;
    public float runningSpeed = 12f;
    private float jumpingPower = 16f;
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] private bool isRunning = false;
    public float runTime = 5f; // Tiempo m�ximo de uso en segundos
    public float runCooldown = 3f; // Tiempo de recarga en segundos
    public float runTimer;
    public float cooldownTimer;
    private bool canRun = true;
    private int lives = 10;
    private int maxLives = 10; // N�mero m�ximo de vidas del jugador
    public Image lifeBarImage; // Referencia a la imagen de la barra de vida


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    void Start()
    {
        UpdateLifeBar();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        HandleRunning();

        Flip();
    }

    private void FixedUpdate()
    {
        float currentSpeed = isRunning ? runningSpeed : speed;
        rb.velocity = new Vector2(horizontal * currentSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void TakeDamage()
    {
        lives--;
        UpdateLifeBar();
        Debug.Log("Vidas restantes: " + lives);

        if (lives <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("El jugador ha muerto.");
        Destroy(gameObject);
        
    }
    private void UpdateLifeBar()
    {
        lifeBarImage.fillAmount = (float)lives / maxLives;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }
    private void HandleRunning()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canRun)
        {
            isRunning = true;
            runTimer = runTime;
        }

        if (isRunning)
        {
            runTimer -= Time.deltaTime;
            if (runTimer <= 0)
            {
                isRunning = false;
                canRun = false;
                cooldownTimer = runCooldown;
            }
        }

        if (!canRun)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                canRun = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
    }
}

