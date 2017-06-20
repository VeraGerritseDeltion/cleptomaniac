using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour {
    public Text text;
    public Text moneyNeeded;
    public static int currentDay = 1;
    public int lastDay;
    public EndGame endGame;

	// Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
		text.text = currentDay.ToString() + " / " + endGame.maxDays.ToString() + " days";
        float i = SaveStats.saveClass.moneyOnBank + SaveStats.saveClass.moneyOnPerson;
        moneyNeeded.text ="goal: " + i.ToString() + " / " + endGame.moneyNeeded + " wallys";
	}

    public void NextDay()
    {
        currentDay++;
    }
}
