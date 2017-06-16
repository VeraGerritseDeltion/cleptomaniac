using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllItems : MonoBehaviour {

    public List<GameObject> allItems = new List<GameObject>();
    public int giveId;
    public List<int> itemId = new List<int>();
    public int items;

    public void Start()
    {

    }
    public void AddGameobject(GameObject item)
    {
        allItems.Add(item);
        giveId++;
        int i = 1;
        itemId.Add(i);
        Id(giveId);
    }

    public void Id(int i)
    {
        if(allItems[i] != null)
        {
            Stealable steal = allItems[i].GetComponent<Stealable>();
            steal.itemId = i;
        }
        
    }

    public void LoadItems()
    {
        for(int i = 0;i < allItems.Count; i++)
        {
            print(SaveStats.saveClass.test.Count);
            if(SaveStats.saveClass.test[i] == 0)
            {

                if (allItems[i] != null)
                {
                    Destroy(allItems[i]);
                    allItems[i] = null;
                    itemId[i] = 0;
                }
            }
        }
    }

    public void SaveStolenItems()
    {
        SaveStats.saveClass.test = itemId;
        print (SaveStats.saveClass.test[allItems.Count - 1]);
    }
}
