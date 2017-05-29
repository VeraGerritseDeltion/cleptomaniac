using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {
    public bool interacting;
    public MoneyManager moneyManager;

	public virtual void Interacting()
    {
        print("inter");
    }
}
