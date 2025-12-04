using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Referencia al GameManager (se encuentra al inicio del juego)
    private GameManager gameManager;

    void Start()
    {
        // 🛠️ CORRECCIÓN DE UNITY: Usa FindAnyObjectByType para buscar el GameManager
        // Esto es un método moderno para encontrar el objeto en la escena.
        gameManager = FindAnyObjectByType<GameManager>();
        
        if (gameManager == null)
        {
            Debug.LogError("ERROR: No se encontró un objeto GameManager en la escena.");
        }
    }

    // Se llama cuando el Collider del personaje entra en el Trigger (la Cuerda)
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto tocado tiene la etiqueta "Rope"
        if (other.CompareTag("Rope"))
        {
            Die();
        }
    }

    // Se llama cuando el personaje choca con un Collider Sólido (si la cuerda NO fuera Trigger)
    private void OnCollisionEnter(Collision collision)
    {
        // Esto es una medida de seguridad, pero con OnTriggerEnter y Is Trigger es suficiente.
        if (collision.gameObject.CompareTag("Rope"))
        {
            Die();
        }
    }

    void Die()
    {
        // Si el personaje ya está inactivo, no hacemos nada (evita doble eliminación)
        if (!gameObject.activeSelf) 
            return;
            
        // 1. Notificar al GameManager que este jugador ha perdido
        if (gameManager != null)
        {
            gameManager.PlayerLost(gameObject);
        }

        // 2. ELIMINACIÓN: Hace que el objeto completo del personaje desaparezca
        gameObject.SetActive(false);
    }
}