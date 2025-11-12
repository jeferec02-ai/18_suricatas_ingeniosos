using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void IrAJuego()
    {
        SceneManager.LoadScene("Game");
    }

    public void IrAInstrucciones()
    {
        SceneManager.LoadScene("Instrucciones");
    }

    public void IrAPersonajes()
    {
        SceneManager.LoadScene("Personajes");
    }

    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("El juego se ha cerrado.");
    }
}
