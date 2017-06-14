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
    public AIManager aiManager;
    public InterfaceManager interfaceManager;
    public bool endDAY;
    public MenuManager menuManager;
     
	void Start () {
		
	}
	

	void Update () {
		if(endDAY == true)
        {
            if (Input.GetKeyDown(KeyCode.P)){
                endDAY = false;
                NextDay();
            }
        }
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
        endDAY = true;
    }

    public IEnumerator SetMoneyOnBank()
    {
        yield return new WaitForSeconds(2);
        InteractManager.moneys.moneyOnBank += InteractManager.moneys.moneyOnPerson;
        InteractManager.moneys.moneyOnPerson = 0;
        wop.text = InteractManager.moneys.moneyOnPerson.ToString();
        wob.text = InteractManager.moneys.moneyOnBank.ToString();
        
    }

    public void NextDay()
    {
        MenuManager.dead = false;
        MenuManager.endDay = false;
        aiManager.wantedState = false;
        interfaceManager.NextDay();
        menuManager.menus = MenuManager.Menus.none;
    }
}
