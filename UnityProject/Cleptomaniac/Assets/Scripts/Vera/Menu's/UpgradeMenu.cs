using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour {
    public Text wop;
    public Text wob;
    public int tier1Cost = 100;
    public int tier2Cost = 250;
    public int tier3Cost = 500;

    public float tier1Extra;
    public float tier2Extra;
    public float tier3Extra;

    public AIManager aiManager;
    public InterfaceManager interfaceManager;
    public bool endDAY;
    public MenuManager menuManager;
    public EndGame endGame;

    public int speedTier;
    public int enduranceTier;
    public int jumpTier;
    public int invCapTier;

    public int keysAmount;
    public int donutAmount;

    public int keysCost;
    public int donutCost;

    public static float moneyTotal;

    public Text speedTierText;
    public Text enduranceTierText;
    public Text jumpTierText;
    public Text invCapTierText;

    public Text keysText;
    public Text donutText;

    public Text moneyLeftOnBank;
    public Text costOnMouse;

    public bool upgrading;
     
	void Start () {
        donutCost = 100;
    }
	

	void Update () {
        if (upgrading == true)
        {
            costOnMouse.transform.position = Input.mousePosition;
        }

	}
    public void Dead()
    {
        SaveStats.saveClass.moneyOnPerson = 0;
        EndDay();
    }

    public void EndDay()
    {
        AIManager.wantedState = false;
        speedTierText.text = "Speed Tier: " + speedTier.ToString();
        donutText.text = "Donut Amount: " + donutAmount.ToString();
        keysText.text = "Keys Amount: " + keysAmount.ToString();
        invCapTierText.text = "Inventory Size Tier: " + invCapTier.ToString();
        jumpTierText.text = "Jump Height Tier : " + jumpTier.ToString();
        enduranceTierText.text = "Endurance Tier:" + enduranceTier.ToString();
        menuManager.menus = MenuManager.Menus.upgrade;
        MenuManager.dead = false;
        MenuManager.endDay = false;
        menuManager.upgrading = true;
        moneyTotal += SaveStats.saveClass.moneyOnPerson;
        SaveStats.saveClass.moneyOnBank += SaveStats.saveClass.moneyOnPerson;
        SaveStats.saveClass.moneyOnPerson = 0;
        moneyLeftOnBank.text = SaveStats.saveClass.moneyOnBank.ToString();
    }
    
public void NextDay()
    {
        if (InterfaceManager.currentDay != endGame.maxDays)
        {
            interfaceManager.NextDay();
            menuManager.upgrading = false;
            menuManager.menus = MenuManager.Menus.none;
            SaveStats.saveClass.inInventory = 0;
        }
        else
        {
            endGame.endgame();
        }
    }

    public void MoreSpeed()
    {
        if (speedTier == 0)
        {
            if (SaveStats.saveClass.moneyOnBank >= tier1Cost)
            {
                Movement.walkSpd *= tier1Extra;
                speedTier++;
                SaveStats.saveClass.moneyOnBank -= tier1Cost;
                moneyTotal += tier1Cost;
            }
        }
        else if (speedTier == 1)
        {
            if (SaveStats.saveClass.moneyOnBank >= tier2Cost)
            {
                Movement.walkSpd *= tier2Extra;
                speedTier++;
                SaveStats.saveClass.moneyOnBank -= tier2Cost;
                moneyTotal += tier2Cost;
            }
        }
        else if(speedTier == 2)
        {
           if (SaveStats.saveClass.moneyOnBank >= tier3Cost)
            {
                Movement.walkSpd *= tier3Extra;
                speedTier++;
                SaveStats.saveClass.moneyOnBank -= tier3Cost;
                moneyTotal += tier3Cost;
            }
        }
        moneyLeftOnBank.text = SaveStats.saveClass.moneyOnBank.ToString();
        speedTierText.text = "Speed Tier: " + speedTier.ToString();
    }

    public void MoreEndurance()
    {
        if (enduranceTier == 0)
        {
            if (SaveStats.saveClass.moneyOnBank >= tier1Cost)
            {
                Movement.enduranceLenght *= tier1Extra;
                enduranceTier++;
                SaveStats.saveClass.moneyOnBank -= tier1Cost;
                moneyTotal += tier1Cost;
            }
        }
        else if (enduranceTier == 1)
        {
            if (SaveStats.saveClass.moneyOnBank >= tier2Cost)
            {
                Movement.enduranceLenght *= tier2Extra;
                enduranceTier++;
                SaveStats.saveClass.moneyOnBank -= tier2Cost;
                moneyTotal += tier2Cost;
            }
        }
        else if (enduranceTier == 2)
        {
            if (SaveStats.saveClass.moneyOnBank == tier3Cost)
            {
                Movement.enduranceLenght *= tier3Extra;
                enduranceTier++;
                SaveStats.saveClass.moneyOnBank -= tier3Cost;
                moneyTotal += tier3Cost;
            }
        }
        moneyLeftOnBank.text = SaveStats.saveClass.moneyOnBank.ToString();
        enduranceTierText.text = "Endurance Tier:" + enduranceTier.ToString();
    }

    public void MoreJump()
    {
        if (jumpTier == 0)
        {
            if (SaveStats.saveClass.moneyOnBank >= tier1Cost)
            {
                Movement.jumpHight *= tier1Extra;
                jumpTier++;
                SaveStats.saveClass.moneyOnBank -= tier1Cost;
                moneyTotal += tier1Cost;
            }
        }
        else if (jumpTier == 1)
        {
            if (SaveStats.saveClass.moneyOnBank >= tier2Cost)
            {
                Movement.jumpHight *= tier2Extra;
                jumpTier++;
                SaveStats.saveClass.moneyOnBank -= tier2Cost;
                moneyTotal += tier2Cost;
            }
        }
        else if (jumpTier == 2)
        {
            if (SaveStats.saveClass.moneyOnBank >= tier3Cost)
            {
                Movement.jumpHight *= tier3Extra;
                jumpTier++;
                SaveStats.saveClass.moneyOnBank -= tier3Cost;
                moneyTotal += tier3Cost;
            }
        }
        moneyLeftOnBank.text = SaveStats.saveClass.moneyOnBank.ToString();
        jumpTierText.text ="Jump Height Tier : " + jumpTier.ToString();
    }

    public void MoreInventory()
    {
        if (invCapTier == 0)
        {
            if (SaveStats.saveClass.moneyOnBank >= tier1Cost)
            {
                SaveStats.saveClass.maxInInventory += 2;
                invCapTier++;
                SaveStats.saveClass.moneyOnBank -= tier1Cost;
                moneyTotal += tier1Cost;
            }
        }
        else if (invCapTier == 1)
        {
            if (SaveStats.saveClass.moneyOnBank >= tier2Cost)
            {
                SaveStats.saveClass.maxInInventory += 3;
                invCapTier++;
                SaveStats.saveClass.moneyOnBank -= tier2Cost;
                moneyTotal += tier2Cost;
            }
        }
        else if (invCapTier == 2)
        {
            if (SaveStats.saveClass.moneyOnBank >= tier3Cost)
            {
                SaveStats.saveClass.maxInInventory += 4;
                invCapTier++;
                SaveStats.saveClass.moneyOnBank -= tier3Cost;
                moneyTotal += tier3Cost;
            }
        }
        moneyLeftOnBank.text = SaveStats.saveClass.moneyOnBank.ToString();
        invCapTierText.text = "Inventory Size Tier: " + invCapTier.ToString();
    }

    public void MoreKeys()
    {
        if (SaveStats.saveClass.moneyOnBank >= keysCost)
        {
            SaveStats.saveClass.moneyOnBank -= keysCost;
            keysAmount++;
            moneyTotal += keysCost;
        }
        moneyLeftOnBank.text = SaveStats.saveClass.moneyOnBank.ToString();
        keysText.text = "Keys Amount: " + keysAmount.ToString();
        
    }

    public void MoreDonut()
    {
        if (SaveStats.saveClass.moneyOnBank >= donutCost)
        {
            SaveStats.saveClass.moneyOnBank -= donutCost;
            donutAmount++;
            moneyTotal += donutCost;
        }
        moneyLeftOnBank.text = SaveStats.saveClass.moneyOnBank.ToString();
        donutText.text = "Donut Amount: " + donutAmount.ToString();

    }

    public void Resume()
    {
        menuManager.menus = MenuManager.Menus.none;
    }
    
    public void SaveStatsNow()
    {
        SaveStats.saveClass.speedTiers = speedTier;
        SaveStats.saveClass.jumpTiers = jumpTier;
        SaveStats.saveClass.enduranceTiers = enduranceTier;
        SaveStats.saveClass.invCapTiers = invCapTier;
        SaveStats.saveClass.keysAmounts = keysAmount;
        SaveStats.saveClass.donutAmounts = donutAmount;
    }

    public void LoadStatsNow()
    {
        speedTier = SaveStats.saveClass.speedTiers;
        jumpTier = SaveStats.saveClass.jumpTiers;
        enduranceTier = SaveStats.saveClass.enduranceTiers;
        invCapTier = SaveStats.saveClass.invCapTiers;
        keysAmount = SaveStats.saveClass.keysAmounts;
        donutAmount = SaveStats.saveClass.donutAmounts;
    }

    public int ShowCost(int i)
    {
        upgrading = true;
        int price = 0;
        if(i == 0)
        {
            
            if(speedTier == 0)
            {
                price = tier1Cost;
            }
            if(speedTier == 1)
            {
                price = tier2Cost;
            }
            if(speedTier == 2)
            {
                price = tier3Cost;
            }
        }
        if (i == 1)
        {

            if (enduranceTier == 0)
            {
                price = tier1Cost;
            }
            if (enduranceTier == 1)
            {
                price = tier2Cost;
            }
            if (enduranceTier == 2)
            {
                price = tier3Cost;
            }
        }
        if (i == 2)
        {

            if (jumpTier == 0)
            {
                price = tier1Cost;
            }
            if (jumpTier == 1)
            {
                price = tier2Cost;
            }
            if (jumpTier == 2)
            {
                price = tier3Cost;
            }
        }
        if (i == 3)
        {

            if (invCapTier == 0)
            {
                price = tier1Cost;
            }
            if (invCapTier == 1)
            {
                price = tier2Cost;
            }
            if (invCapTier == 2)
            {
                price = tier3Cost;
            }
        }
        if (i == 4)
        {
            price = donutCost;            
        }
        if (i == 5)
        {
            price = keysCost;
        }
        return price;
    }
}
