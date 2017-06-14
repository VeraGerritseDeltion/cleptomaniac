using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour {

    public Text wop;
    public Text wob;
    public int tier1Cost;
    public int tier2Cost;
    public int tier3Cost;
 
	void Start () {
		
	}
	

	void Update () {
		
	}
    public void Dead()
    {
        InteractManager.moneys.inInventory = 0;
        EndDay();
    }

    public void EndDay()
    {
        wop.text = InteractManager.moneys.moneyOnPerson.ToString();
        wob.text = InteractManager.moneys.moneyOnBank.ToString();
        StartCoroutine(SetMoneyOnBank());
    }

    public IEnumerator SetMoneyOnBank()
    {
        yield return new WaitForSeconds(2);
        InteractManager.moneys.moneyOnBank += InteractManager.moneys.moneyOnPerson;
        InteractManager.moneys.moneyOnPerson = 0;
        wop.text = InteractManager.moneys.moneyOnPerson.ToString();
        wob.text = InteractManager.moneys.moneyOnBank.ToString();
    }
}
