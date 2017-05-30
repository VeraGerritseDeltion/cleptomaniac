using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealable : Interactable {
    public float price;
   


    public override void Interacting()
    {
        if (moneyManager.inInventory < moneyManager.maxInInventory)
        {
            moneyManager.moneyOnPerson += price;
            GameObject.Destroy(gameObject);
            moneyManager.inInventory++;
        }
    }
}
