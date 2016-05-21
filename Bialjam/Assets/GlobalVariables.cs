﻿using UnityEngine;
using System.Collections;

public class GlobalVariable
{
    // system variables
    public int buttonSize = 2;

    // game variables
    public int score;
    public int highscore = 0;
    public string bestname = "-";
    public int level;
	public int playerHealth = 100;
	public float BulletForwardForce = 400.0f;

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
    public void SetPlayerHealth(int health)
    {
        playerHealth = health;
    }
    public void ChangePlayerHealth(int health)
    {
        playerHealth += health;
    }
    public int GetPlayerHealth()
    {
        return playerHealth;
    }
}
