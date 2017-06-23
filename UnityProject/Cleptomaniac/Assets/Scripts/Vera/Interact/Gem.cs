using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Interactable{
    public GameObject gem;
	void Start () {
		
	}
	
	void Update () {
		
	}
    public override void Interacting()
    {
        gem.AddComponent<Rigidbody>();
    }
}
