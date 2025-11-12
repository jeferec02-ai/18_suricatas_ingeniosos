using UnityEngine;

public class CuerdaRotation : MonoBehaviour
{
    [Header("Velocidad de rotación (grados por segundo)")]
    public float rotationSpeed = 100f;

    [Header("Eje de rotación (por defecto Y)")]
    public Vector3 rotationAxis = Vector3.up;

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
