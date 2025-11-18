using UnityEngine;
 
public class SuricataJump : MonoBehaviour
{
    public float jumpForce = 4f;
    private Rigidbody rb;
    private bool isGrounded;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
 
    void Update()
    {
        // Saltar solo si está tocando el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Reinicia velocidad vertical antes de saltar
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
 
            // Aplica impulso de salto
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
 
            isGrounded = false;
        }
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        // Detecta si tocó el suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = true;
        }
    }
}