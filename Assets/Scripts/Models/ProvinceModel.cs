using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Models/ProvinceModel")]
public class ProvinceModel : ScriptableObject
{

    public Color32 CurrentlySelectedProvince;

    public Dictionary<Color32, Province> Provinces { get; set; } = new Dictionary<Color32, Province>();
}

public struct Province
{
    public int id;
    public string name;
}