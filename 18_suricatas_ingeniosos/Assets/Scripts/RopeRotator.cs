using UnityEngine;

public class RopeRotator : MonoBehaviour
{
    // Variables públicas para configurar en el Inspector de Unity
    [Tooltip("Velocidad de rotación de la cuerda (grados por segundo).")]
    public float rotationSpeed = 100f; 
    
    [Tooltip("Objeto vacío alrededor del cual girará la cuerda (ej: RopePivot).")]
    public Transform pivotPoint;

    [Tooltip("Eje del mundo sobre el cual girará la cuerda. (Vector3.up es estándar).")]
    public Vector3 worldAxis = Vector3.up;
    
    // Referencia al GameManager (se encuentra automáticamente)
    private GameManager gameManager;
    
    // Variables privadas para el conteo de saltos
    private float totalRotation = 0f;

    void Start()
    {
        // 🛠️ CORRECCIÓN DE UNITY: Usa FindAnyObjectByType para buscar el GameManager
        gameManager = FindAnyObjectByType<GameManager>();

        if (pivotPoint == null)
        {
            Debug.LogError("¡ERROR! El 'Pivot Point' no está asignado en el script RopeRotator. Asigna un objeto vacío (ej: RopePivot) como centro de rotación.");
        }
    }

    void Update()
    {
        if (pivotPoint == null)
            return;

        // 1. Calcula la rotación que ocurre en este frame (tiempo transcurrido * velocidad)
        float angleThisFrame = rotationSpeed * Time.deltaTime; 
        
        // 2. Aplica la rotación alrededor del punto de pivote
        transform.RotateAround(pivotPoint.position, worldAxis, angleThisFrame);
        
        // 3. Acumula la rotación total
        totalRotation += angleThisFrame;
        
        // 4. LÓGICA DEL CONTADOR DE SALTOS
        // Si la rotación acumulada supera o iguala 360 grados, se cuenta un salto exitoso
        if (totalRotation >= 360f)
        {
            if (gameManager != null)
            {
                // Llama a la función de puntuación en el GameManager
                gameManager.AddScore();
            }
            // Reinicia el contador restando 360f para evitar pérdida de precisión y continuar el conteo
            totalRotation -= 360f; 
        }
    }
}