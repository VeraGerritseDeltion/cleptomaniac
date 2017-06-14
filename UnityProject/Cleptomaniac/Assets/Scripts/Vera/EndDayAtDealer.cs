using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDayAtDealer : Interactable {

    public MenuManager menumanager;

    public override void Interacting()
    {
        MenuManager.endDay = true;
        InteractManager.moneys.inInventory = 0;
    }
}
