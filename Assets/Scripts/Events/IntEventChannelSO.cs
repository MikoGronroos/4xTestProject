using System;
using UnityEngine;

[CreateAssetMenu(menuName = "EventChannels/IntEventChannel")]
public class IntEventChannelSO : ScriptableObject
{
    public Action<int> Event;

    public void Register(Action<int> listener)
    {
        Event += listener;
    }

    public void Unregister(Action<int> listener)
    {
        Event -= listener;
    }
}
