using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel1"); // Reemplaza con el nombre exacto de tu escena del juego
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }
}
