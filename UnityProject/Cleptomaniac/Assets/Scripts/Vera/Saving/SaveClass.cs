﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveClass {
    
    public int speedTiers;
    public int enduranceTiers;
    public int jumpTiers;
    public int invCapTiers;
    public int keysAmounts;
    public int donutAmounts;

    public float speed;
    public float jumpHeight;
    public float endurance;
    public int inventorySpace;

    public bool wanted;
    public Vector3 charPos;
    public int currentDay;
    public List<int> test = new List<int>();

    public float moneyOnPerson;
    public float moneyOnBank;
    public float totalMoney;
    public int maxInInventory = 3;
    public int inInventory;

    public int difficulty;

    public bool EverPlayedOnThisPc;

	public void Start () {

        SaveStats.saveClass = this;
    }

    public void played()
    {
        MenuManager.everPlayed = EverPlayedOnThisPc;
    }

    public void Save()
    {
        speed = Movement.walkSpd;
        jumpHeight = Movement.jumpHight;
        endurance = Movement.enduranceLenght;
        inventorySpace = SaveStats.saveClass.maxInInventory;
        charPos = Movement.ownPos;
        wanted = AIManager.wantedState;
        currentDay = InterfaceManager.currentDay;
        moneyOnBank = SaveStats.saveClass.moneyOnBank;
        moneyOnPerson = SaveStats.saveClass.moneyOnPerson;
        difficulty = EndGame.difficulty;
        EverPlayedOnThisPc = MenuManager.everPlayed;
        totalMoney = UpgradeMenu.moneyTotal;
    }

    public void Load()
    {
        Movement.walkSpd = speed;
        Movement.jumpHight = jumpHeight;
        Movement.enduranceLenght = endurance;
        SaveStats.saveClass.maxInInventory = inventorySpace;
        Movement.ownPos = charPos;
        AIManager.wantedState = wanted;
        InterfaceManager.currentDay = currentDay;
        EndGame.difficulty = difficulty;
        UpgradeMenu.moneyTotal = totalMoney;
    }
}
