using System;
using UnityEngine;

[CreateAssetMenu(menuName = "EventChannels/BoolEventChannel")]
public class BoolEventChannelSO : ScriptableObject
{

    public Action<bool> Event;

    public void Register(Action<bool> listener)
    {
        Event += listener;
    }

    public void Unregister(Action<bool> listener) 
    {
        Event -= listener;
    }

}
