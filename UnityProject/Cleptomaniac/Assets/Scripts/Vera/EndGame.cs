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

    public bool countingUpBank;
    public bool countingUsed;

    public static int difficulty;

    public float moneyBank;
    public float moneyUsedInt;
    public float moneyTot;

    public Text moneyInBank;
    public Text moneyUsed;
    public Text moneyTotal;

    void Start () {
        maxDays = 5;
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
        if(countingUpBank == true)
        {
            moneyBank--;
            moneyTot++;
            if(moneyBank == 0)
            {
                countingUpBank = false;
                countingUsed = true;
            }
        }
        if(countingUsed == true)
        {
            moneyUsedInt--;
            moneyTot++;
            if(moneyUsedInt == 0)
            {
                countingUsed = false;
            }
        }
    }

    public void endgame()
    {
        StartCoroutine(InBank());
    }

    public IEnumerator InBank()
    {
        yield return new WaitForSeconds(0.5f);
        moneyBank = SaveStats.saveClass.moneyOnBank;
        StartCoroutine(Used());
    }
    public IEnumerator Used()
    {
        yield return new WaitForSeconds(0.5f);
        countingUpBank = true;
        print(UpgradeMenu.moneyTotal);
        moneyUsedInt = UpgradeMenu.moneyTotal - SaveStats.saveClass.moneyOnBank;
    }
}
