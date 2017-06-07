using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MoneyManager {
    public float moneyOnPerson;
    public float moneyOnBank;
    public int maxInInventory = 1;
    public int inInventory;


   public void Start()
    {
        InteractManager.moneys = this;
    }
}
