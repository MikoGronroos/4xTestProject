using System;
using UnityEngine;

[CreateAssetMenu(menuName = "EventChannels/TransformEventChannel")]
public class TransformEventChannelSO : ScriptableObject
{

    private Action<Transform> _event;

    public void Register(Action<Transform> listener)
    {
        _event += listener;
    }

    public void Unregister(Action<Transform> listener)
    {
        _event -= listener;
    }

    public void Raise(Transform transform)
    {
        _event?.Invoke(transform);
    }


}
