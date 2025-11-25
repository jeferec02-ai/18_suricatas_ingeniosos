using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 6f;
    public int playerId = 1;
    public LayerMask groundMask;
    public Transform groundCheck;
    public float groundRadius = 0.2f;

    Rigidbody rb;
    Animator anim;
    bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        ReadInput();
    }

    void ReadInput()
    {
        float h = 0f;
        bool jump = false;

        if (playerId == 1)
        {
            h = (Input.GetKey(KeyCode.D) ? 1f : 0f) + (Input.GetKey(KeyCode.A) ? -1f : 0f);
            jump = Input.GetKeyDown(KeyCode.W);
        }
        else if (playerId == 2)
        {
            h = (Input.GetKey(KeyCode.RightArrow) ? 1f : 0f) + (Input.GetKey(KeyCode.LeftArrow) ? -1f : 0f);
            jump = Input.GetKeyDown(KeyCode.UpArrow);
        }

        // Movimiento horizontal
        Vector3 vel = rb.linearVelocity;
        vel.x = h * moveSpeed;
        rb.linearVelocity = vel;

        if (anim) anim.SetFloat("Speed", Mathf.Abs(h));

        // Detección de suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        // Debug para verificar si detecta suelo
        if (isGrounded)
            Debug.Log("EN EL SUELO");
        else
            Debug.Log("NO TOCANDO EL SUELO");

        // Salto
        if (jump && isGrounded)
        {
            Debug.Log("SALTO EJECUTADO");

            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

            if (anim) anim.SetTrigger("Jump");
        }
    }
}
