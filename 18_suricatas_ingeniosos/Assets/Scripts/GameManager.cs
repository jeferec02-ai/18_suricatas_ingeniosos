using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Players")]
    public GameObject[] players;

    [Header("Victory")]
    public GameObject victoryCanvas;
    public AudioClip winnerClip;       // Audio de victoria
    public AudioClip playerLostClip;   // Audio cuando un jugador muere

    private bool gameEnded = false;

    void Start()
    {
        victoryCanvas.SetActive(false);
    }

    // Llamado cuando un jugador pierde (desde RopeKill)
    public void PlayerLost()
    {
        if (gameEnded) return;

        int alivePlayers = 0;

        foreach (GameObject p in players)
        {
            if (p != null && p.activeInHierarchy)
                alivePlayers++;
            else
            {
                // 🔊 Si el jugador murió, reproducir audio
                if (playerLostClip != null)
                    AudioSource.PlayClipAtPoint(playerLostClip, Camera.main.transform.position);
            }
        }

        if (alivePlayers <= 1)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;

        // 🔊 Reproducir audio de victoria
        if (winnerClip != null)
            AudioSource.PlayClipAtPoint(winnerClip, Camera.main.transform.position);

        victoryCanvas.SetActive(true);

        Invoke(nameof(PauseGame), 0.5f); // Delay para que se escuche el audio
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    // BOTÓN "VOLVER A JUGAR"
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // BOTÓN "SALIR"
    public void QuitGame()
    {
        Application.Quit();
    }
}

