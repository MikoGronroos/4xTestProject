using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Models/ProvinceModel")]
public class ProvinceModel : ScriptableObject
{

    [SerializeField] private Province currentlySelectedProvince;
    public Province CurrentlySelectedProvince { get { return currentlySelectedProvince; } set { currentlySelectedProvince = value; provinceSelectedEvent.Raise(currentlySelectedProvince); } }

    [SerializeField] private ProvinceEventChannelSO provinceSelectedEvent;

    public Dictionary<Color32, Province> Provinces { get; set; } = new Dictionary<Color32, Province>();
}

public struct Province
{
    public int id;
    public string name;
}