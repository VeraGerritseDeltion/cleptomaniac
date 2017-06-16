using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealable : Interactable {
    public float price;
    public AllItems allItem;
    public int itemId;


    public void Start()
    {
        StartCoroutine(AddItem());
    }

    public IEnumerator AddItem()
    {
        yield return new WaitForSeconds(1);
        allItem = GetComponentInParent<AllItems>();
        allItem.AddGameobject(gameObject);
    }

    public override void Interacting()
    {;
        if (SaveStats.saveClass.inInventory < SaveStats.saveClass.maxInInventory)
        {
            SaveStats.saveClass.moneyOnPerson += price;
            GameObject.Destroy(gameObject);
            SaveStats.saveClass.inInventory++;
            allItem.allItems[itemId] = null;
            allItem.itemId[itemId] = 0;
        }
    }
}
