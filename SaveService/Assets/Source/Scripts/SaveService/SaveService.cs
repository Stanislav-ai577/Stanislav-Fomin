using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

//[RequireComponent(typeof(PlayerFactory))]
public class SaveService : MonoBehaviour
{
    private string _filePath;
    private PlayerFactory _playerFactory;
    public LevelSaveData SaveData { get; private set; }

    private void OnEnable()
    {
        _filePath = Application.persistentDataPath + "/Save.Json";
        if (File.Exists(_filePath))
        {
            Debug.Log("Load level");
            Load();
        }
        else
        {
            Debug.Log("Save Level");
            SaveData = new LevelSaveData();
            Save();
        }
    }

    private void Awake()
    {
        _playerFactory = GetComponent<PlayerFactory>();
    }

    [ContextMenu("Save")]
    public void Save()
    {
        using (FileStream file = File.Create(_filePath))
        {
            new BinaryFormatter().Serialize(file, SaveData);
        }
    }
    
    [ContextMenu("Load")]
    public void Load()
    {
        using (FileStream file = File.Open(_filePath, FileMode.Open))
        {
            object LoadeData = new BinaryFormatter().Deserialize(file);
            SaveData = (LevelSaveData)LoadeData;
        }
        LoadLevel();
    }

    private void LoadLevel()
    {
        foreach (SaveData data in SaveData.Data.Values)
        {
            Debug.Log(SaveData.Data.Count);
            if (data.Type == typeof(Player))
            {
                PlayerSaveData playerSaveData = (PlayerSaveData)data;
                _playerFactory.CreatePlayer(playerSaveData.Position.ToVector()).Load(data.Id, this);
            }
        }
    }
}

[Serializable]
public class LevelSaveData
{
    public Dictionary<string, SaveData> Data = new Dictionary<string, SaveData>();

    public void AddData(string id, SaveData data)
    {
        Data.TryAdd(id, data);
    }

    public bool TrygetData<T>(string id, out T data) where T : SaveData
    {
        foreach (string key in Data.Keys)
        {
            if (key == id)
            {
                data = (T)Data[key];
                return true;
                
            }
        }
        data = null;
        return true;
    }
    
    public LevelSaveData()
    {
       
    }
}

[Serializable]
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

[Serializable]
public class Vector3Serilize
{
    public float x { get; private set; }
    public float y { get; private set; }
    public float z { get; private set; }

    public Vector3Serilize(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }

    public Vector3 ToVector()
    {
        return new Vector3(x, y, z);
    }
}
