using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour, IsaveData
{
    [field: SerializeField] public string Id { get; set; } = "";

    [SerializeField] private SaveService _saveService;

    private void Start()
    {
        if (Id == "")
        {
            Id = Random.Range(0, 100000).ToString();
        }
    }

    [ContextMenu("Save")]
    public void Save()
    {
        _saveService.SaveData.AddData(Id, new PlayerSaveData(Id, typeof(Player), transform.position));
    }
    
    [ContextMenu("Load")]
    public void Load(String id, SaveService saveService)
    {
        _saveService = saveService;
        Id = id;
        if (_saveService.SaveData.TrygetData(Id, out PlayerSaveData playerSaveData))
        {
            transform.position = playerSaveData.Position.ToVector();
        }
    }
}

[Serializable]
public class PlayerSaveData : SaveData
{
    public Vector3Serilize Position { get; private set; }

    public PlayerSaveData(string id, Type type, Vector3 position) : base(id, type)
    {
        Position = new Vector3Serilize(position);
    }
}