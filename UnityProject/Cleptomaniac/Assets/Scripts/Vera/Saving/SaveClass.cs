using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveClass {
    
    public List<MoneyManager> moneyManager = new List<MoneyManager>();
    //public MoneyManager moneymanager;
    public int test;
	public void Start () {
            moneyManager.Add(new MoneyManager()); 
	}
	


}
