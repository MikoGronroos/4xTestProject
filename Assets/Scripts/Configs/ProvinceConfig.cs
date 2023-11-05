using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Configs/ProvinceConfig")]
public class ProvinceConfig : ScriptableObject
{
    public Dictionary<Color32, Province> Provinces { get; set; } = new Dictionary<Color32, Province>();
}

public struct Province
{
    public int id;
    public string name;
}