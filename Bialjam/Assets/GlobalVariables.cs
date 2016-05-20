using UnityEngine;
using System.Collections;

public class GlobalVariable
{
    // system variables
    public int buttonSize = 2;

    // game variables
    public int score;
    public int highscore;
    public string bestname;

    private static GlobalVariable instance;
    public static GlobalVariable Instance
    {
        get
        {
            if(instance==null)
            {
                instance = new GlobalVariable();
            }
            return instance;
        }
    }
}
