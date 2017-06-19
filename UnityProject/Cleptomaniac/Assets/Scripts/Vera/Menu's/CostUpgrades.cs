using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostUpgrades : MonoBehaviour {
    public UpgradeMenu upgrade;
    public int id;
	void Start () {
		
	}
	

	void Update () {
		
	}

    public void GiveId()
    {
        upgrade.costOnMouse.text = upgrade.ShowCost(id).ToString();
        upgrade.costOnMouse.enabled = true;
    }
    public void ExitMouse()
    {
        upgrade.costOnMouse.enabled = false;
        upgrade.upgrading = false;
    }
}
