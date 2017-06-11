using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractManager : MonoBehaviour {
    public float rayCastLenght;
    public RaycastHit targetHit;
    public Interactable interactable;
    public Text e;
    public static MoneyManager moneys;
    public bool inventoryFull;
    public string eText;
    public string invFull;
    public bool test;
    public Image value;
    delegate void StealNoticed();
    StealNoticed stealNoticed;

    void Start()
    {
        e.text = eText;
        value.enabled = false;
    }
    void Update (){
        
        if (Physics.Raycast(transform.position, transform.forward, out targetHit, rayCastLenght) && targetHit.collider.GetComponent<Interactable>() != null )
        {
            interactable = targetHit.collider.GetComponent<Interactable>();
            test = true;
            if(targetHit.collider.GetComponent<Stealable>() != null)
            {
                value.enabled = true;
                value.fillAmount = interactable.value / 3;                
            }
            
            if (interactable.interacting == false)
            {
                e.enabled = true;
               
                if (Input.GetButtonDown("Interact"))
                {
                    interactable.moneyManager = moneys;
                    interactable.Interacting();
                    if (moneys.inInventory == moneys.maxInInventory && targetHit.collider.tag != "Door")
                    {
                    inventoryFull = true;
                    }
                    print(moneys.inInventory + "testing" + moneys.moneyOnPerson);
                }
                
            }
            if(inventoryFull == true )
            {
                 e.enabled = true;
                 e.text = invFull;
            }
        }
        else
        {
            value.enabled = false;
        }
        if ( test == false)
        {
            e.enabled = false;
            inventoryFull = false;
            e.text = eText;
        }

        test = false;
	}
}
