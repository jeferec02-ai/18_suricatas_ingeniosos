using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // ---------- MENU ----------
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("Instrucciones2");
    }

    public void GoToCharacters()
    {
        SceneManager.LoadScene("Personajes2");
    }

    // ---------- VOLVER ----------
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // ---------- SALIR ----------
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }
}
