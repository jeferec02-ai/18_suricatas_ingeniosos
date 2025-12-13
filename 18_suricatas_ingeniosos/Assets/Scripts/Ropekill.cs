using UnityEngine;

public class RopeKill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Si lo que tocó la cuerda es un jugador
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name + " PERDIÓ");

            // Desaparece de la escena
            other.gameObject.SetActive(false);
        }
    }
}
