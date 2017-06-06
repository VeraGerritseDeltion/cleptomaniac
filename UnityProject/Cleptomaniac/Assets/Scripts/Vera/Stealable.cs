using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealable : Interactable {
    public float price;
    
   


    public override void Interacting()
    {
        print(moneyManager.inInventory);
        if (moneyManager.inInventory < moneyManager.maxInInventory)
        {
            moneyManager.moneyOnPerson += price;
            print(moneyManager.moneyOnPerson);
            
            GameObject.Destroy(gameObject);
            moneyManager.inInventory++;
        }
    }
}
