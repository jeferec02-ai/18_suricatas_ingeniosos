using UnityEngine;

public class JumpController : MonoBehaviour
{
    [Header("Animator")]
    private Animator animator;

    [Header("Jump Settings")]
    public KeyCode jumpKey = KeyCode.Space;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        if (animator == null)
            Debug.LogError("No se encontró Animator en " + gameObject.name);
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            animator.SetTrigger("Jump");
        }
    }
}
