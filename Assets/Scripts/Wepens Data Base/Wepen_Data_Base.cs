using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Wepen
{
    public Sprite Wepen_Icon;

    public string Wepen_Name;

    public string Wepen_Description;

    public string Wepen_Id;

    public GameObject weaponPrefab;

    public float weaponPrice;

};

[CreateAssetMenu(fileName = "Data Base" , menuName = " Assets/DataBase")]
public class Wepen_Data_Base : ScriptableObject
{

    public List<Wepen> WeaponsList;


    public int SelectedWeaponId;

    public Vector3Int SelectedTowerPlace;

}
