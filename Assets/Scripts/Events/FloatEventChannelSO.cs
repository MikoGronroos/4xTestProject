using System;
using UnityEngine;

[CreateAssetMenu(menuName = "EventChannels/FloatEventChannel")]
public class FloatEventChannelSO : ScriptableObject
{
    public Action<float> Event;

    public void Register(Action<float> listener)
    {
        Event += listener;
    }

    public void Unregister(Action<float> listener)
    {
        Event -= listener;
    }
}

