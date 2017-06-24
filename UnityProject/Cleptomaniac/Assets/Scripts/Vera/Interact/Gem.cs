using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Interactable{
    public GameObject gem;
    public Animator yass;

    public override void Interacting()
    {
        yass.enabled = false;
        gem.AddComponent<Rigidbody>();
    }
}
