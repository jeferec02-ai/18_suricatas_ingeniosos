using UnityEngine;

public class JumpController : MonoBehaviour
{
    [Header("Animator")]
    private Animator animator;

    [Header("Jump Settings")]
    public KeyCode jumpKey = KeyCode.Space;

    private bool isJumping = false;

    void Awake()
    {
        // Busca automáticamente el Animator en el personaje o sus hijos
        animator = GetComponentInChildren<Animator>();

        if (animator == null)
            Debug.LogError("No se encontró Animator en " + gameObject.name);
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            StartJump();
        }
    }

    void StartJump()
    {
        isJumping = true;
        animator.SetTrigger("Jump");
    }

    public void EndJump()
    {
        isJumping = false;
    }
}
