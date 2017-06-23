using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    public static bool inGameStaticInterface;
    public static bool playedThisSession;
    public static bool endDay;
    public static bool dead;
    public static bool everPlayed;
    public static bool inMenu;
    public static bool playing;

    public Canvas mainMenuCanvas;
    public Canvas pauseMenuCanvas;
    public Canvas upgradeMenuCanvas;
    public Canvas difficultyCanvas;
    public Canvas interfaceCanvas;
    public Canvas endGameCanvas;

    public SaveManager saveManager;
    public UpgradeMenu upgradeMenu;
    public InterfaceManager interfaceM;
    public Movement movement;
    public EndGame endGame;

    public Text wop;
    public Text wob;
    public Camera mainMenuCam;
    public bool upgrading;
    public bool day;
    public GameObject continueButton;

    public enum Menus {main,pause,upgrade,ingame,none,difficulty,end}
    public Menus menus;

	void Start () {
        menus = Menus.main;
        if(playedThisSession == true)
        {
            menus = Menus.difficulty;
        }
	}
	
	void Update () {
        if (SaveStats.saveClass != null)
        {
            wop.text = SaveStats.saveClass.moneyOnPerson.ToString();
            wob.text = SaveStats.saveClass.moneyOnBank.ToString();
        }
        if(menus == Menus.main || menus == Menus.upgrade)
        {
            mainMenuCam.depth = 1;
        }
        else
        {
            mainMenuCam.depth = -1;
        }
        if (upgrading == true)
        {
            movement.NewDay();
        }
        if (dead == true)
        {
            upgradeMenu.Dead();
            AIManager.wantedState = false;
        }
        if (endDay == true && InterfaceManager.currentDay != endGame.maxDays)
        {
            upgradeMenu.EndDay();
        }
        else if(InterfaceManager.currentDay == endGame.maxDays && endDay == true && day == false)
        {
            endGame.endgame();
            menus = Menus.end;
            day = true;
            SaveStats.saveClass.moneyOnBank = SaveStats.saveClass.moneyOnPerson;
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
            if(everPlayed == true)
            {
                continueButton.SetActive(true);
            }
            else
            {
                continueButton.SetActive(false);
            }
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
        if(menus == Menus.difficulty)
        {
            difficultyCanvas.enabled = true;
        }
        else
        {
            difficultyCanvas.enabled = false;
        }
        if(menus == Menus.end)
        {
            endGameCanvas.enabled = true;
        }
        else
        {
            endGameCanvas.enabled = false;
        }

	}
    public void exitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        if 
            (playing == false)
        {
            menus = Menus.difficulty;
            if (playedThisSession == true)
            {
                saveManager.newGameLoading();
            }
            playedThisSession = true;
            everPlayed = true;
        }

    }

    public void Continue()
    {
        if (playing == false)
        {
            saveManager.loading();
            upgradeMenu.LoadStatsNow();
            menus = Menus.none;
            playedThisSession = true;
            movement.LoadPos();
        }
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
        upgradeMenu.SaveStatsNow();
        saveManager.saveGame();
        Application.Quit();
    }

    public void EndDay()
    {
        endDay = false;
        menus = Menus.none;
    }

    public void Easy()
    {
        menus = Menus.none;
        EndGame.difficulty = 0;
    }

    public void Medium()
    {
        menus = Menus.none;
        EndGame.difficulty = 1;
    }

    public void Hard()
    {
        menus = Menus.none;
        EndGame.difficulty = 2;
    }
}
