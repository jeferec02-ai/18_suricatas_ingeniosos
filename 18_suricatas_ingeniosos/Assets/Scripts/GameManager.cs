using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // --- CAMBIO CLAVE 1: Implementación del Singleton ---
    public static GameManager Instance; 
    // --------------------------------------------------

    [Tooltip("Arrastra a todos los avatares (Tomy, Valak, etc.) aquí.")]
    public List<GameObject> allPlayers; 
    
    [Header("UI y Puntuación")]
    public Text scoreText; // Asigna un objeto Text UI aquí
    public GameObject winnerPanel; // Asigna un Panel/Imagen con el texto "Winner" aquí
    
    private int playersRemaining;
    private int score = 0;

    // --- CAMBIO CLAVE 2: Función Awake para configurar el Singleton ---
    void Awake() 
    {
        // Si no hay una instancia (Instance) creada, esta será la única.
        if (Instance == null)
        {
            Instance = this;
            // Si el GameManager debe sobrevivir entre escenas, descomenta la línea de abajo:
            // DontDestroyOnLoad(gameObject); 
        }
        else
        {
            // Si ya hay otro GameManager, destruye este duplicado.
            Destroy(gameObject); 
        }
    }
    // -----------------------------------------------------------------

    void Start()
    {
        playersRemaining = allPlayers.Count;
        
        // Esconde el panel de victoria al inicio
        if (winnerPanel != null)
            winnerPanel.SetActive(false);
            
        UpdateScoreDisplay();
    }

    public void PlayerLost(GameObject player)
    {
        // Nos aseguramos de que el jugador no se cuente dos veces si choca varias veces
        if (player.activeSelf) 
        {
            playersRemaining--;
            Debug.Log(player.name + " ha perdido. Quedan: " + playersRemaining);

            CheckWinCondition();
        }
    }

    void CheckWinCondition()
    {
        // 1. CONDICIÓN DE VICTORIA: Queda solo 1 jugador (o ninguno)
        if (playersRemaining <= 1)
        {
            Time.timeScale = 0; // Detiene el tiempo en el juego
            
            // Encuentra al ganador (el último activo)
            string winnerName = "Nadie";
            foreach (var player in allPlayers)
            {
                if (player.activeSelf)
                {
                    winnerName = player.name;
                    break;
                }
            }

            // Muestra la imagen de "Winner"
            if (winnerPanel != null)
            {
                winnerPanel.SetActive(true);
            }
            
            Debug.Log("Juego Terminado. Ganador: " + winnerName);
        }
    }
    
    // 2. CONTADOR DE SALTOS
    public void AddScore()
    {
        score++;
        UpdateScoreDisplay();
    }
    
    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Saltos: " + score.ToString();
        }
    }
}