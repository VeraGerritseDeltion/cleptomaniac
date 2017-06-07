using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveClass {
    

    public MoneyManager moneymanager;
    public int test;
	public void Start () {
        if(moneymanager == null)
        {
            moneymanager = new MoneyManager();
            
        }
        moneymanager.Start();
    }
	


}
