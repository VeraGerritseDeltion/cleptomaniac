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
    public static bool playedThisSession;
    public Text wop;
    public Text wob;
    public static bool endDay;
    public static bool dead;
    public UpgradeMenu upgradeMenu;
    public static bool playing;
    public enum Menus {main,pause,upgrade,ingame,none}
    public Menus menus;
    public InterfaceManager interfaceM;
    public Canvas interfaceCanvas;

	void Start () {
        menus = Menus.main;
        if(playedThisSession == true)
        {
            menus = Menus.none;
        }
	}
	

	void Update () {
        wop.text = InteractManager.moneys.moneyOnPerson.ToString();
        wob.text = InteractManager.moneys.moneyOnBank.ToString();
        if (dead == true)
        {
            upgradeMenu.Dead();
        }
        if (endDay == true)
        {
            upgradeMenu.EndDay();
        }
        if(upgradeMenu.endDAY == true)
        {
            menus = Menus.upgrade;
        }
        if (inGameStaticInterface == true)
        {
            menus = Menus.ingame;
        }

		if (menus != Menus.none)
        {
            Movement.movementStuck = true;
            playing = false;
            interfaceCanvas.enabled = false;
        }
        else
        {
            Movement.movementStuck = false;
            playing = true;
            interfaceCanvas.enabled = true;
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
        if(menus == Menus.upgrade)
        {
            upgradeMenuCanvas.enabled = true;
            mainMenuCam.depth = 1;
        }
        else
        {
            upgradeMenuCanvas.enabled = false;
            mainMenuCam.depth = -1;
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

    public void EndDay()
    {
        endDay = false;
        menus = Menus.none;
    }
}
