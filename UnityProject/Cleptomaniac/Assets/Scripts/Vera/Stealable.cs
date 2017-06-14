using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealable : Interactable {
    public float price;
    
   


    public override void Interacting()
    {;
        if (InteractManager.moneys.inInventory < InteractManager.moneys.maxInInventory)
        {
            InteractManager.moneys.moneyOnPerson += price;
            GameObject.Destroy(gameObject);
            InteractManager.moneys.inInventory++;
        }
    }
}
