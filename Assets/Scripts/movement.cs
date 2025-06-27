using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashSpeed = 10f;
    public float dashLength = 0.3f;
    public float dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private float activeMoveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activeMoveSpeed = moveSpeed;
    }

    void Update()
    {
        // Hareket girişi al
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        // Dash başlat
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space tuşuna basıldı!");
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        // Dash süresini azalt
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        // Dash bekleme süresi
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

        // Rigidbody'ye hareket uygula
        rb.linearVelocity = moveInput * activeMoveSpeed;
    }
}