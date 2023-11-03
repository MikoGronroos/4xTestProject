using System;
using UnityEngine;

[CreateAssetMenu(menuName = "EventChannels/Vector3EventChannel")]
public class Vector3EventChannelSO : ScriptableObject
{
    private Action<Vector3> _event;

    public void Register(Action<Vector3> listener)
    {
        _event += listener;
    }

    public void Unregister(Action<Vector3> listener)
    {
        _event -= listener;
    }

    public void Raise(Vector3 vector3)
    {
        _event?.Invoke(vector3);
    }

}

