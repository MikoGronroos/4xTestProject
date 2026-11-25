using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Country Config")]
public class CountryConfig : ScriptableObject
{
    [SerializeField] private Country[] countries;

    public Dictionary<string, Country> Countries = new Dictionary<string, Country>();

    private void OnEnable()
    {
        foreach (Country country in countries)
        {
            Countries[country.Id] = country;
        }
    }

}

[Serializable]
public struct Country
{
    public string Id;
    public string Name;
    public Color32 CountryColor;
    public int[] Provinces;
}
