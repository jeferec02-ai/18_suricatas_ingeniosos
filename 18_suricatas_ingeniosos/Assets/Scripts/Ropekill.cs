using UnityEngine;

public class RopeKill : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        if (gameManager == null)
            Debug.LogError("No se encontró GameManager en la escena");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name + " PERDIÓ");

            // Desactiva SOLO el jugador tocado
            other.gameObject.SetActive(false);

            // Notifica al GameManager
            if (gameManager != null)
                gameManager.PlayerLost();
        }
    }
}
