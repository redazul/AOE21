using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Brain,
    Heart,
    Lungs,
    Blood

};

[CreateAssetMenu(fileName = "Items", menuName = "ScriptableObjects/Item")]
public class ItemDataContainer : ScriptableObject
{

    // public string itemName;
    // public string itemName;

    public ItemType itemType;

    public Vector3 spawnPoint;




}