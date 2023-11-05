using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class ProvinceCreator : MonoBehaviour
{

    [SerializeField] private TextAsset provinces;
    [SerializeField] private TextAsset provincesTransform;

    [SerializeField] private ProvinceConfig _model;
    [SerializeField] private ProvincePositionsConfig _positions;

    private void Awake()
    {
        #region Province Data

        string fs = provinces.text;
        string[] fLines = Regex.Split(fs, "\n");

        for (int i = 0; i < fLines.Length; i++)
        {
            if (fLines[i] == "")
            {
                continue;
            }
            string valueLine = fLines[i];
            string[] values = Regex.Split(valueLine, ";");
            Province province = new Province { id = Int32.Parse(values[0]), name = values[4] };
            Color32 key = new Color32((byte)Int32.Parse(values[1]), (byte)Int32.Parse(values[2]), (byte)Int32.Parse(values[3]), 255);
            if (!_model.Provinces.ContainsKey(key))
            {
                _model.Provinces[key] = province;
            }
        }

        #endregion

        #region Province Transform Data


        string data = provincesTransform.text;
        string[] dataLines = Regex.Split(data, "\n");
        string[] splitValues;
        float x = 0;
        float z = 0;
        for (int i = 0; i < dataLines.Length; i++)
        {
            if (dataLines[i] == "")
            {
                continue;
            }
            if (Regex.Match(dataLines[i], "^[0-9]{0,4}={").Success)
            {
                int id = Int32.Parse(Regex.Match(dataLines[i], "^[0-9]{0,4}").Value);
                if (Regex.Match(dataLines[i + 1], "position={").Success)
                {
                    splitValues = Regex.Split(dataLines[i + 2], " ");
                    x = float.Parse(splitValues[2]);
                    z = float.Parse(splitValues[3]);
                }
                _positions.ProvinceTransformData[id] = new ProvinceTransformData { Position = new Vector2(x,z) };
            }
        }

        #endregion

    }

}