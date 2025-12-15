using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownManager : MonoBehaviour
{
    public TextMeshProUGUI countdownText;

    public RopeRotator ropeRotator;        // La cuerda
    public JumpController[] players;       // Los jugadores

    void Start()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        // 🔒 Bloquea el juego
        ropeRotator.enabled = false;

        foreach (var player in players)
            player.enabled = false;

        countdownText.gameObject.SetActive(true);

        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "¡YA!";
        yield return new WaitForSeconds(0.7f);

        countdownText.gameObject.SetActive(false);

        // 🔓 Arranca el juego
        ropeRotator.enabled = true;

        foreach (var player in players)
            player.enabled = true;
    }
}
