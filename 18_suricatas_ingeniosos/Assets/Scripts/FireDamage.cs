using UnityEngine;

public class FireDamage : MonoBehaviour
{
    public float damagePerSecond = 20f;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health h = other.GetComponent<Health>();
            if (h != null)
            {
                h.TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
    }
}
