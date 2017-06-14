using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour {
    public Text text;
    public int currentDay;
    public int lastDay;

	// Use this for initialization
	void Start () {
        text.text = currentDay.ToString() + " / " + lastDay.ToString() + "days";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextDay()
    {
        currentDay++;
        text.text = currentDay.ToString() + " / " + lastDay.ToString() + "days";
    }
}
