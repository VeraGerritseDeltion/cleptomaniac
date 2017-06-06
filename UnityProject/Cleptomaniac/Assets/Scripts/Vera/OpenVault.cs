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
                Movement.movementStuck = false;
                interacting = false;
                MenuManager.inGameStaticInterface = false;
            }
        }
    }
    public override void Interacting()
    {
        padLock.enabled = true;
        Movement.movementStuck = true;
        interacting = true;
        MenuManager.inGameStaticInterface = true;
    }

    public void CodeCheck()
    {
        if (codeInput == code)
        {
            vault.SetBool("OpenDoor", true);
            padLock.enabled = false;
            Movement.movementStuck = false;
            doorOpend = true;
            MenuManager.inGameStaticInterface = false;
        }
        else
        {
            print("wrong");
        }
            
       }
}
