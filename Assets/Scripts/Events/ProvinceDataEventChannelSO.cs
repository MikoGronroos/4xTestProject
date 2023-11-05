using System;
using UnityEngine;

[CreateAssetMenu(menuName = "EventChannels/ProvinceEventChannel")]
public class ProvinceDataEventChannelSO : ScriptableObject
{

    private Action<string, ProvinceData> _event;

    public void Register(Action<string, ProvinceData> listener)
    {
        _event += listener;
    }

    public void Unregister(Action<string, ProvinceData> listener)
    {
        _event -= listener;
    }

    public void Raise(string name, ProvinceData provinceData)
    {
        _event?.Invoke(name, provinceData);
    }


}
