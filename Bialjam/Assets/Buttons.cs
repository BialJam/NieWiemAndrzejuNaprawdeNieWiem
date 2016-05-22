using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.IO;


public class Buttons
{
	public static void StartGame()
	{
		Time.timeScale = 1;
		GlobalVariable.Instance.level = 0;
		GlobalVariable.Instance.SetPlayerHealth(100);
		GlobalVariable.Instance.score = 0;
		//Debug.Log("Gra wystartowala");
		SceneManager.LoadScene("Level 1");
	}
	public static void RetryLevel()
	{
		Time.timeScale = 1;
		if (!GlobalVariable.Instance.hardcore) {
			GlobalVariable.Instance.SetPlayerHealth (100);
			GlobalVariable.Instance.score = GlobalVariable.Instance.startLevelScore;
		}
		SceneManager.LoadScene("Level " + GlobalVariable.Instance.level);
	}
    public static void ExitGame()
    {
        Debug.Log("Wyszedlem z gry");
        Application.Quit();
    }
    public static void PauseGame()
    {
        Time.timeScale = 1;
        Debug.Log("Gra zapauzowana");
    }
    public static void SaveScore(string s)
    {
        int high = int.Parse(File.ReadAllText(Application.dataPath + "/highscore.txt"));
        if (high < GlobalVariable.Instance.score)
        {
            File.WriteAllText(Application.dataPath + "/highscore.txt", GlobalVariable.Instance.score.ToString());
            File.WriteAllText(Application.dataPath + "/bestname.txt", s);
            GlobalVariable.Instance.highscore = GlobalVariable.Instance.score;
            GlobalVariable.Instance.bestname = s;
            Debug.Log("Lepszy wynik nadpisany");
        }
        Debug.Log("Zapisane");
    }
    public static void LosedGame()
    {
        SceneManager.LoadScene("Lose");
    }
}
