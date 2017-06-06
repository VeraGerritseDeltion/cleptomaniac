using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MoneyManager {
    public float moneyOnPerson;
    public static float moneyOnBank;
    public int maxInInventory = 1;
    public int inInventory;


    void Update()
    {
        moneyOnPerson++;
    }
}
