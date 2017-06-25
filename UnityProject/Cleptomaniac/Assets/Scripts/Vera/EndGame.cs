using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {
    public int maxDays = 5;
    public int moneyNeeded;

    public int diff1Money;
    public int diff2Money;
    public int diff3Money;

    public Text win;
    public Text lose;


    public static int difficulty;

    void Start () {
	}
	
	void Update () {
        if (difficulty == 0)
        {
            moneyNeeded = diff1Money;
        }
        if (difficulty == 1)
        {
            moneyNeeded = diff2Money;
        }
        if (difficulty == 2)
        {
            moneyNeeded = diff3Money;
        }
    }

    public void endgame()
    {
        if (SaveStats.saveClass.moneyOnBank >= moneyNeeded)
        {
            win.enabled = true;
            lose.enabled = false;
        }
        else
        {
            win.enabled = false;
            lose.enabled = true;
        }
    }
}
