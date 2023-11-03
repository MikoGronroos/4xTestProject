using System;
using UnityEngine;

[CreateAssetMenu(menuName = "EventChannels/ProvinceEventChannel")]
public class ProvinceEventChannelSO : ScriptableObject
{

    private Action<Province> _event;

    public void Register(Action<Province> listener)
    {
        _event += listener;
    }

    public void Unregister(Action<Province> listener)
    {
        _event -= listener;
    }

    public void Raise(Province province)
    {
        _event?.Invoke(province);
    }


}
