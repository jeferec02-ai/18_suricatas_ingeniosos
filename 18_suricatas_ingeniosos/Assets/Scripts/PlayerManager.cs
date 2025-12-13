using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // --- CAMBIO CLAVE 3: Se elimina la variable 'gameManager' privada. ---
    // private GameManager gameManager; // Ya no es necesaria.
    // ---------------------------------------------------------------------

    void Start()
    {
        // Se elimina el código que buscaba el GameManager. ¡Ya no es necesario!
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
        // Esto es una medida de seguridad
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
        // --- CAMBIO CLAVE 4: Uso de GameManager.Instance (Acceso directo y seguro) ---
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayerLost(gameObject);
        }
        // ----------------------------------------------------------------------------

        // 2. ELIMINACIÓN: Hace que el objeto completo del personaje desaparezca
        gameObject.SetActive(false);
    }
}