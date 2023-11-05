using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/ProvincePositions")]
public class ProvincePositionsConfig : ScriptableObject
{

    public Dictionary<int, ProvinceTransformData> ProvinceTransformData = new Dictionary<int, ProvinceTransformData>();
}

public struct ProvinceTransformData
{
    public Vector2 Position;

    public override string ToString()
    {
        return $"x = {Position.x}, z = {Position.y}";
    }
}