using UnityEngine;
using UnityEngine.Events;

public class TargetableComponent : MonoBehaviour, ITargetable
{
    [SerializeField]
    private UnityEvent _onTargetedEvent;
    [SerializeField]
    private UnityEvent<ContactData> _onReachedEvent;

    public Transform Transform => transform;

    public void OnTargeted()
    {
        _onTargetedEvent.Invoke();
    }

    public void OnReached(ContactData data)
    {
        _onReachedEvent.Invoke(data);
    }
}
