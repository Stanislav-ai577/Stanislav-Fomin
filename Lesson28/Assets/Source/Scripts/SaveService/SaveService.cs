using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveService : MonoBehaviour
{
    private string _filePath;
    public LevelSaveData SaveData { get; private set; }

    private void OnEnable()
    {
        _filePath = Application.persistentDataPath + "/Save.Json";
        SaveData = new LevelSaveData();
    }

    private void Awake()
    {
        if (File.Exists(_filePath))
        {
            Load();
        }
        else
        {
            SaveData = new LevelSaveData();
        }
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
    }
}

[Serializable]
public class LevelSaveData
{
    public Dictionary<string, SaveData> _data = new Dictionary<string, SaveData>();

    public void AddData(string id, SaveData data)
    {
        _data.TryAdd(id, data);
    }

    public bool TrygetData<T>(string id, out T data) where T : SaveData
    {
        foreach (string key in _data.Keys)
        {
            if (key == id)
            {
                data = (T)_data[key];
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
