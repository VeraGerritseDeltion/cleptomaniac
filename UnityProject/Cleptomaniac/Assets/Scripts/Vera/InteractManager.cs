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

	void Update () {

        if (Physics.Raycast(transform.position, transform.forward, out targetHit, rayCastLenght) && targetHit.collider.GetComponent<Interactable>() != null )
        {
            interactable = targetHit.collider.GetComponent<Interactable>();
            if (interactable.interacting == false)
            {
                e.enabled = true;
                if (Input.GetButtonDown("Interact"))
                {
                    interactable.moneyManager = moneys;
                    interactable.Interacting();
                }
            }
            
        }
        else
             {
                 e.enabled = false;
             }
       
	}

    public void Interact()
    {
        
    }
}
