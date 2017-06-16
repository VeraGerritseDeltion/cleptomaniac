using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDayAtDealer : Interactable {

    public MenuManager menumanager;

    public override void Interacting()
    {
        MenuManager.endDay = true;
        SaveStats.saveClass.inInventory = 0;
    }
}
