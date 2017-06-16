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
    public enum Menus {main,pause,upgrade,ingame,none,upgrading}
    public Menus menus;
    public InterfaceManager interfaceM;
    public Canvas interfaceCanvas;
    public Canvas upgradeMenu2Canvas;
    public bool upgrading;
    public static bool inMenu;
    public Movement movement;

	void Start () {
        menus = Menus.main;
        if(playedThisSession == true)
        {
            menus = Menus.none;
        }
	}
	

	void Update () {
        if (SaveStats.saveClass != null)
        {
            wop.text = SaveStats.saveClass.moneyOnPerson.ToString();
            wob.text = SaveStats.saveClass.moneyOnBank.ToString();
        }
        if(menus == Menus.main || menus == Menus.upgrade || menus == Menus.upgrading)
        {
            mainMenuCam.depth = 1;
        }
        else
        {
            mainMenuCam.depth = -1;
        }
        if (upgrading == true)
        {
            menus = Menus.upgrading;
            movement.NewDay();
        }
        if(menus == Menus.upgrading)
        {
            upgradeMenu2Canvas.enabled = true;
        }
        else
        {
            upgradeMenu2Canvas.enabled = false;
        }
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
            print(menus);
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
            inMenu = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Movement.movementStuck = false;
            playing = true;
            interfaceCanvas.enabled = true;
            inMenu = false;
            Cursor.lockState = CursorLockMode.Locked;
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
        }
        else
        {
            mainMenuCanvas.enabled = false;
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
        }
        else
        {
            upgradeMenuCanvas.enabled = false;
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
        saveManager.loading();
        upgradeMenu.LoadStatsNow();      
        menus = Menus.none;
        playedThisSession = true;
        movement.LoadPos();
    }
    public void Resume()
    {
        menus = Menus.none;
    }
    public void MainMenuAndSave()
    {
        menus = Menus.main;
        saveManager.saveGame();
        upgradeMenu.SaveStatsNow();
    }
    public void ExitAndSave()
    {
        Application.Quit();
        saveManager.saveGame();
        upgradeMenu.SaveStatsNow();
    }

    public void EndDay()
    {
        endDay = false;
        menus = Menus.none;
    }
}
