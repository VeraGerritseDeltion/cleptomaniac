﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenVault : Interactable {

    public Animator vault;
    public bool interact;
    public int code;
    public Canvas padLock;
    public int codeInput;
    public bool doorOpend;
    public Text pcCode;


    void Start()
    {
        code = Random.Range(1000, 9999);
        pcCode.text = code.ToString();
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
            MenuManager.inGameStaticInterface = false;
            doorOpend = true;
        }
        else
        {
            print("wrong");
        }
            
       }
    public void NewDay()
    {
        vault.SetBool("OpenDoor", false);
        code = Random.Range(1000, 9999);
        pcCode.text = code.ToString();
        interacting = false;
    }
}
