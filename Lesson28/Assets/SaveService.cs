using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OpenCover.Framework.Model;
using UnityEngine;
using File = System.IO.File;
using Random = UnityEngine.Random;

public class SaveService : MonoBehaviour
{
    private string _filePath;

    private void OnEnable()
    {
        _filePath = Application.persistentDataPath + "/Save.json";
    }

    [ContextMenu("Save")]
    public void Save()
    {
       string json = JsonConvert.SerializeObject(new LevelSaveData());
       File.WriteAllText(Application.persistentDataPath + "/Save.json", json);
       Debug.Log(Application.persistentDataPath);
    }
    
    [ContextMenu("Load")]
    public void Load()
    {
        string json = File.ReadAllText(_filePath);
        LevelSaveData levelSaveData = JsonConvert.DeserializeObject<LevelSaveData>(json);
    }
}

public class LevelSaveData
{
    private Dictionary<string, SaveData> _data = new Dictionary<string, SaveData>();

    public void AddDate(string id, SaveData data)
    {
        _data.TryAdd(id, data);
        TryGetData("player", out PlayerSaveData playerSaveData);
    }

    public bool TryGetData<T>(string id, out T data) where T : SaveData
    {
        data = null;
        return true;
    }
    
    public LevelSaveData()
    {
      
    }
}

public class SaveData
{
    public string Id { get; private set; }
    public Type Type { get; private set; }

    public SaveData(string id, Type type)
    {
        Id = id;
        Type = type;
    }
}

public class PlayerSaveData : SaveData
{
    public PlayerSaveData(string id, Type type) : base(id, type)
    {
    }
}
