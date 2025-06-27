using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;  // H�z ayar�
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = 5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;
    void Start()
    {
        activeMoveSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input'u al
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize(); // �apraz giderken h�z sabit kals�n

        rb.linearVelocity = moveInput * activeMoveSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        // Rigidbody'ye hareket uygula
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
