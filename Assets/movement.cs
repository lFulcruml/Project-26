using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;  // H�z ayar�
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input'u al
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize(); // �apraz giderken h�z sabit kals�n
    }

    void FixedUpdate()
    {
        // Rigidbody'ye hareket uygula
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
