using UnityEngine;

public class JumpController : MonoBehaviour
{
    // --- Variables Públicas para Ajuste ---
    [Tooltip("La fuerza vertical que se aplicará para el salto.")]
    public float jumpForce = 5f;
    
    // Cada personaje usará una tecla diferente (configúrala en el Inspector).
    [Tooltip("La tecla que activará el salto (ejemplo: KeyCode.Space).")]
    public KeyCode jumpKey = KeyCode.Space; 

    // --- Componentes Privados ---
    private Rigidbody rb;
    private Animator anim; // Componente para la animación
    private bool isGrounded = true; 


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); // Obtenemos el Animator

        if (rb == null)
        {
            Debug.LogError("ERROR: Rigidbody no encontrado en " + gameObject.name);
        }
        if (anim == null)
        {
            Debug.LogWarning("Advertencia: Animator no encontrado en " + gameObject.name + ". El salto físico funcionará, pero no la animación.");
        }
    }


    void Update()
    {
        // Revisa si la tecla de salto para este personaje ha sido presionada Y si está en el suelo.
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }
    }


    void Jump()
    {
        isGrounded = false;

        // 1. Activa la animación
        if (anim != null)
        {
            // Activa el Trigger llamado "Jump" que creamos en el Animator Controller.
            anim.SetTrigger("Jump"); 
        }
        
        // 2. Aplica la fuerza física
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


    // Detección de Colisión (Para Resetear el Salto)
    private void OnCollisionEnter(Collision collision)
    {
        // Asegúrate de que el suelo tiene la etiqueta "Ground" o el nombre "Plane".
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.name == "Plane")
        {
            isGrounded = true;
        }
    }
}