using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/ProvinceData")]
public class ProvinceDataConfig : ScriptableObject
{

    [SerializeField] private ProvinceData[] provinceDatas;

    private Dictionary<int, ProvinceData> _provinceDatas { get; set; } = new Dictionary<int, ProvinceData>();

    public ProvinceData GetProvinceData(int id)
    {
        ProvinceData data = null;
        if (_provinceDatas.ContainsKey(id))
        {
            data = _provinceDatas[id];
        }
        return data;
    }

    private void OnEnable()
    {
        foreach (var data in provinceDatas)
        {
            _provinceDatas[data.Id] = data;
        }
    }

}

[Serializable]
public class ProvinceData
{
    public int Id;
    public int Population;
}