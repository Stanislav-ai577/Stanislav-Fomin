using System;
using UnityEngine;

public class Player : MonoBehaviour, IsaveData
{
    public string Id { get; set; } = "Player";

    [SerializeField] private SaveService _saveService;

    private void Start()
    {
        Load();
    }

    [ContextMenu("Save")]
    public void Save()
    {
        _saveService.SaveData.AddData(Id, new PlayerSaveData(Id, typeof(Player), transform.position));
    }
    
    [ContextMenu("Load")]
    public void Load()
    {
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