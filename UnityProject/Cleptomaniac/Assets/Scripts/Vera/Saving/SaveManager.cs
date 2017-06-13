﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SaveManager : MonoBehaviour {
    public SaveClass safeClass;

	void Start () {
        safeClass = new SaveClass();
        
        newGame(safeClass);
        safeClass.Start();
    }
	

	void Update () {

        
    }
    public void saveGame()
    {
        SavedGame(safeClass);
        safeClass.Start();
    }

    public void loading()
    {
        safeClass = Load();
        print(safeClass.test);
    }
    public void newGameLoading()
    {
        safeClass = NewGameLoad();
        print(safeClass.test);
        print("iets");
        safeClass.Start();

    }
    public void newGame(SaveClass toSave)
    {
        var serializer = new XmlSerializer(typeof(SaveClass));
        using (var stream = new System.IO.FileStream(Application.dataPath + "/NewGame.xml", FileMode.Create))
        {
            serializer.Serialize(stream, toSave);
        }
    }

    public void SavedGame(SaveClass toSave)
    {
        var serializer = new XmlSerializer(typeof(SaveClass));
        using (var stream = new System.IO.FileStream(Application.dataPath + "/SavedGame.xml", FileMode.Create))
        {
            serializer.Serialize(stream, toSave);
        }
        toSave.moneymanager.save();
        InteractManager.moneys = null;

    }

    public SaveClass Load()
    {
        var serializer = new XmlSerializer(typeof(SaveClass));
        using (var stream = new System.IO.FileStream(Application.dataPath + "/SavedGame.xml", FileMode.Open))
        {
            return serializer.Deserialize(stream) as SaveClass;
        }
    }
    public SaveClass NewGameLoad()
    {
        var serializer = new XmlSerializer(typeof(SaveClass));
        using (var stream = new System.IO.FileStream(Application.dataPath + "/NewGame.xml", FileMode.Open))
        {
            return serializer.Deserialize(stream) as SaveClass;
        }
    }
}
