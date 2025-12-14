using UnityEngine;

public class RopeRotator : MonoBehaviour
{
    [Tooltip("Velocidad de rotación de la cuerda (grados por segundo).")]
    public float rotationSpeed = 100f;

    [Tooltip("Objeto vacío alrededor del cual girará la cuerda (ej: RopePivot).")]
    public Transform pivotPoint;

    [Tooltip("Eje del mundo sobre el cual girará la cuerda.")]
    public Vector3 worldAxis = Vector3.up;

    void Start()
    {
        if (pivotPoint == null)
        {
            Debug.LogError(
                "ERROR: El 'Pivot Point' no está asignado en RopeRotator. " +
                "Asigna un objeto vacío (ej: RopePivot) como centro de rotación."
            );
        }
    }

    void Update()
    {
        if (pivotPoint == null)
            return;

        // Rotación de este frame
        float angleThisFrame = rotationSpeed * Time.deltaTime;

        // Rotar la cuerda alrededor del pivote
        transform.RotateAround(pivotPoint.position, worldAxis, angleThisFrame);
    }
}
