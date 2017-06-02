using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenVault : Interactable {

    public Animator vault;
    public bool interact;
    public int code;
    public Canvas padLock;
    public int codeInput;
    public bool doorOpend;
    public Movement movement;


    void Start()
    {
        code = Random.Range(1000, 9999);
        padLock.enabled = false;
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (doorOpend == false)
            {
                padLock.enabled = false;
                movement.movementStuck = false;
                interacting = false;
            }
        }
    }
    public override void Interacting()
    {
        padLock.enabled = true;
        movement.movementStuck = true;
        interacting = true;
    }

    public void CodeCheck()
    {
        if (codeInput == code)
        {
            vault.SetBool("OpenDoor", true);
            padLock.enabled = false;
            movement.movementStuck = false;
            doorOpend = true;
        }
        else
        {
            print("wrong");
        }
            
       }
}
