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

            if(moneyBank == 0)
            {
                countingUpBank = false;
                countingUsed = true;
            }
            else
            {
                moneyBank--;
                print(moneyBank);
                moneyTot++;
                moneyInBank.text = moneyBank.ToString();
                moneyTotal.text = moneyTot.ToString();
            }
        }
        if(countingUsed == true)
        {

            if (moneyUsedInt != 0)
            {
                moneyUsedInt--;
            moneyTot++;
            moneyUsed.text = moneyUsedInt.ToString();
            moneyTotal.text = moneyTot.ToString();
            }
            else if(moneyUsedInt == 0)
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
        moneyInBank.text = moneyBank.ToString();
        moneyTotal.text = moneyTot.ToString();
        StartCoroutine(Used());
    }
    public IEnumerator Used()
    {
        yield return new WaitForSeconds(0.5f);
        countingUpBank = true;
        print(UpgradeMenu.moneyTotal);
        moneyUsed.text = moneyUsedInt.ToString();
    }
}
