﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SaveManager : MonoBehaviour {
    public SaveClass safeClass;
    public Restart restart;
    public AllItems allItems;
    public SaveClass tempLoad;

	void Start () {
        safeClass = new SaveClass();
        if(File.Exists(Application.dataPath + "/SavedGame.xml"))
        {
            tempLoad = Load();
        }
        else
        {
            tempLoad = new SaveClass();
        }
        
        
        tempLoad.played();
        safeClass.Start();

    }
	

	void Update () {

        
    }
    public void saveGame()
    {
        safeClass.Start();
        safeClass.Save();
        allItems.SaveStolenItems();
        SavedGame(safeClass);
        tempLoad = Load();
    }

    public void loading()
    {
        safeClass = tempLoad;
        safeClass.Start();
        safeClass.played();
        safeClass.Load();
        allItems.LoadItems();
    }
    public void newGameLoading()
    {
        safeClass.Start();
        NewGameLoad();
    }

    public void SavedGame(SaveClass toSave)
    {
        var serializer = new XmlSerializer(typeof(SaveClass));
        using (var stream = new System.IO.FileStream(Application.dataPath + "/SavedGame.xml", FileMode.Create))
        {
            serializer.Serialize(stream, toSave);
        }
        toSave.Save();
    }

    public SaveClass Load()
    {
        var serializer = new XmlSerializer(typeof(SaveClass));
        using (var stream = new System.IO.FileStream(Application.dataPath + "/SavedGame.xml", FileMode.Open))
        {
            return serializer.Deserialize(stream) as SaveClass;
        }
    }
    public void NewGameLoad()
    {
        restart.Restarted();
    }
}
