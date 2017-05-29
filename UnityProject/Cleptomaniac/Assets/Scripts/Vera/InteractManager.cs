using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractManager : MonoBehaviour {
    public float rayCastLenght;
    public RaycastHit targetHit;
    public Interactable interactable;
    public Text e;
    public MoneyManager moneys;
    public bool inventoryFull;
    public string eText;
    public string invFull;
    public bool test;

    void Start()
    {
        e.text = eText;
    }
    void Update () {
        
        if (Physics.Raycast(transform.position, transform.forward, out targetHit, rayCastLenght) && targetHit.collider.GetComponent<Interactable>() != null )
        {
            interactable = targetHit.collider.GetComponent<Interactable>();
            test = true;
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
                }
                
            }
            if(inventoryFull == true )
            {
                 e.enabled = true;
                 e.text = invFull;
                
                 //StartCoroutine(FullInventory());
            }
        }
      if( test == false)
        {
            e.enabled = false;
            inventoryFull = false;
            e.text = eText;
        }

        test = false;
	}

  /*  public IEnumerator FullInventory()
    {
        yield return new WaitForSeconds(2);
        inventoryFull = false;
        e.text = eText;
    }
*/
}
