using UnityEngine;

public class JumpController : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpHeight = 2f;
    public float jumpAirTime = 0.5f;
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Audio")]
    public AudioClip jumpSound;

    private bool isJumping = false;
    private Vector3 startPosition;

    private Animator animator;
    private AudioSource audioSource;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        startPosition = transform.position;
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

        // Animación
        if (animator != null)
        {
            animator.SetTrigger("Jump");
        }

        // 🔊 Sonido del salto
        if (audioSource != null && jumpSound != null)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(jumpSound);
        }

        // Subir
        transform.position = startPosition + Vector3.up * jumpHeight;

        Invoke(nameof(EndJump), jumpAirTime);
    }

    void EndJump()
    {
        transform.position = startPosition;
        isJumping = false;
    }
}
