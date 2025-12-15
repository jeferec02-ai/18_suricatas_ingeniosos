using UnityEngine;
using System.Collections;

public class JumpController : MonoBehaviour
{
    [Header("Input")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Jump Settings")]
    public float jumpHeight = 1.2f;      // Qué tan alto sube
    public float jumpDuration = 0.5f;    // Cuánto dura el salto total

    [Header("Audio")]
    public AudioClip jumpSound;

    private Animator animator;
    private AudioSource audioSource;
    private bool isJumping = false;
    private Vector3 startPosition;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (animator == null)
            Debug.LogError("Animator no encontrado en " + gameObject.name);

        if (audioSource == null)
            Debug.LogError("AudioSource no encontrado en " + gameObject.name);

        startPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            StartCoroutine(JumpRoutine());
        }
    }

    IEnumerator JumpRoutine()
    {
        isJumping = true;

        // 🎬 animación
        animator.ResetTrigger("Jump");
        animator.SetTrigger("Jump");

        // 🔊 sonido
        if (jumpSound != null)
            audioSource.PlayOneShot(jumpSound);

        float halfDuration = jumpDuration / 2f;
        float elapsed = 0f;

        // SUBE
        while (elapsed < halfDuration)
        {
            float t = elapsed / halfDuration;
            transform.position = startPosition + Vector3.up * Mathf.Lerp(0, jumpHeight, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;

        // BAJA
        while (elapsed < halfDuration)
        {
            float t = elapsed / halfDuration;
            transform.position = startPosition + Vector3.up * Mathf.Lerp(jumpHeight, 0, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = startPosition;
        isJumping = false;
    }
}
