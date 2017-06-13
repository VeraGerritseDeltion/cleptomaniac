using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MoneyManager {
    public float moneyOnPerson;
    public float moneyOnBank;
    public int maxInInventory = 5;
    public int inInventory;


   public void Start()
    {
        InteractManager.moneys = this;
    }
    public void save()
    {
        moneyOnBank = InteractManager.moneys.moneyOnBank;
        moneyOnPerson = InteractManager.moneys.moneyOnPerson;
    }
}
