using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class ProvinceCreator : MonoBehaviour
{

    [SerializeField] private TextAsset provinces;

    [SerializeField] private ProvinceModel _model;

    private void Awake()
    {
        string fs = provinces.text;
        string[] fLines = Regex.Split(fs, "\n");


        Debug.Log(fLines.Length);
        for (int i = 0; i < fLines.Length; i++)
        {
            if (fLines[i] == "")
            {
                continue;
            }
            Debug.Log(fLines[i]);
            string valueLine = fLines[i];
            string[] values = Regex.Split(valueLine, ";");
            Province province = new Province { id = Int32.Parse(values[0]), name = values[4] };
            Color32 key = new Color32((byte)Int32.Parse(values[1]), (byte)Int32.Parse(values[2]), (byte)Int32.Parse(values[3]), 255);
            if (!_model.Provinces.ContainsKey(key))
            {
                _model.Provinces[key] = province;
            }
        }
        Debug.Log(_model.Provinces.Count);
    }

}