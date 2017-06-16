using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour {
    public Text text;
    public static int currentDay = 1;
    public int lastDay;

	// Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
		text.text = currentDay.ToString() + " / " + lastDay.ToString() + " days";
	}

    public void NextDay()
    {
        currentDay++;
        text.text = currentDay.ToString() + " / " + lastDay.ToString() + " days";
    }
}
