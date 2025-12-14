using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Singleton (ambas formas)
    public static GameManager instance;
    public static GameManager Instance => instance;

    [Header("Players")]
    public GameObject[] players;

    [Header("Audio")]
    public AudioClip loseSound;
    public AudioClip winSound;

    private AudioSource audioSource;
    private bool gameEnded = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void CheckGameState()
    {
        if (gameEnded) return;

        int alivePlayers = 0;
        GameObject lastPlayerAlive = null;

        foreach (GameObject player in players)
        {
            if (player.activeInHierarchy)
            {
                alivePlayers++;
                lastPlayerAlive = player;
            }
        }

        if (alivePlayers == 1)
        {
            gameEnded = true;
            StartCoroutine(EndGame(lastPlayerAlive));
        }
    }

    IEnumerator EndGame(GameObject winner)
    {
        // 🔥 Perdedor x2
        audioSource.PlayOneShot(loseSound);
        yield return new WaitForSeconds(loseSound.length);
        audioSource.PlayOneShot(loseSound);

        yield return new WaitForSeconds(0.5f);

        // 🏆 Ganador x2
        audioSource.PlayOneShot(winSound);
        yield return new WaitForSeconds(winSound.length);
        audioSource.PlayOneShot(winSound);

        Debug.Log("GANADOR: " + winner.name);
    }
}
