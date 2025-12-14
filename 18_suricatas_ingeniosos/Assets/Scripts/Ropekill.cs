using UnityEngine;

public class RopeKill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name + " PERDIÓ");

            other.gameObject.SetActive(false);

            GameManager.instance.CheckGameState();
        }
    }
}
