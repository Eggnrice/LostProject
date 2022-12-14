using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public static SaveData saveData;
    string SavePath => Path.Combine(Application.persistentDataPath, "save.data");

    private void Awake()
    {
        if (saveData == null)
        {
            Load();
        }

        else
        {

            Save();
        }


    }

    private void Save()
    {
        FileStream file = null;
        try
        {
            if (!Directory.Exists(Application.persistentDataPath))
            {
                Directory.CreateDirectory(Application.persistentDataPath);
            }
            file = File.Create(SavePath);
            var bf = new BinaryFormatter();

        }
        catch (Exception e)
        {
            Debug.Log(e);

        }
        finally
        {
            if (file != null)
                file.Close();
        }
    }

    private void Load()
    {
        FileStream file = null;
        try
        {
            file = File.Open(SavePath, FileMode.Open);
            var bf = new BinaryFormatter();
            saveData = (SaveData)bf.Deserialize(file);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            saveData = new SaveData();
        }
        finally
        {
            if (file != null)
                file.Close();
        }
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Game");
        TimeController.instance.BeginTimer();
    }
    public void OnUpgradeButtonClick()
    {
        Debug.Log("To do next week");
        Debug.Log(saveData.goldCoins);
    }
    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
