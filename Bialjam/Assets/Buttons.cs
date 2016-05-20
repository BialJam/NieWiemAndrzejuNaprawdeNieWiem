using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons
{
    public static void StartGame()
    {
        Time.timeScale = 1;
        Debug.Log("Gra wystartowala");
        SceneManager.LoadScene("Game");
    }
    public static void ExitGame()
    {
        Debug.Log("Wyszedlem z gry");
        Application.Quit();
    }
    public static void PauseGame()
    {
        Debug.Log("Gra zapauzowana");
    }
}
