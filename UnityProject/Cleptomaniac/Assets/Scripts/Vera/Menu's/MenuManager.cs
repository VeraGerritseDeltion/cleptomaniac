using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    public static bool inGameStaticInterface;
    public Canvas mainMenuCanvas;
    public Canvas pauseMenuCanvas;
    public Canvas upgradeMenuCanvas;
    public Camera mainMenuCam;
    public SaveManager saveManager;
    public bool playedThisSession;
    public Text wop;
    public Text wob;

    public enum Menus {main,pause,upgrade,ingame,none}
    public Menus menus;

	void Start () {
        menus = Menus.main;
	}
	

	void Update () {
        wop.text = InteractManager.moneys.moneyOnPerson.ToString();
        wob.text = InteractManager.moneys.moneyOnBank.ToString();
        if (inGameStaticInterface == true)
        {
            menus = Menus.ingame;
        }

		if (menus != Menus.none)
        {
            Movement.movementStuck = true;
        }
        else
        {
            Movement.movementStuck = false;
        }
        if(Input.GetButtonDown("Cancel"))
        {
            if (menus == Menus.ingame)
            {
                menus = Menus.none;
            }
            else if ( menus == Menus.pause)
            {
                menus = Menus.none;
            }
            else if (menus == Menus.none)
            {
                menus = Menus.pause;
            }
        }
      

        if(menus == Menus.main)
        {
            mainMenuCanvas.enabled = true;
            mainMenuCam.depth = 1;
        }
        else
        {
            mainMenuCanvas.enabled = false;
            mainMenuCam.depth = -1;
        }

        if(menus == Menus.pause)
        {
            pauseMenuCanvas.enabled = true;
        }
        else
        {
            pauseMenuCanvas.enabled = false;
        }
	}
    public void exitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        menus = Menus.none;
        if (playedThisSession == true)
        {
            saveManager.newGameLoading();
        }
        playedThisSession = true;
    }

    public void Continue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        saveManager.loading();        
        menus = Menus.none;
        playedThisSession = true;
    }
    public void Resume()
    {
        menus = Menus.none;
    }
    public void MainMenuAndSave()
    {
        //save
        menus = Menus.main;
        saveManager.saveGame();
    }
    public void ExitAndSave()
    {
        //save
        Application.Quit();
        saveManager.saveGame();
    }
}
