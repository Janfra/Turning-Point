using UnityEngine;

public class TargetablePushComponent : MonoBehaviour, ITargetable
{
    [SerializeField]
    private Rigidbody2D _rigidbody;

    public Transform Transform => transform;
    
    [Header("Debugging")]
    public LogComponent Logger;

    public void OnTargeted()
    {
        Logger?.Log("Targeted Push", this); 
    }

    public void OnReached(ContactData data)
    {
        Logger?.Log($"Pushed with force: {data.Force} on direction: {data.Direction}", this);
        _rigidbody.linearVelocity = Vector2.zero;
        _rigidbody.AddForce(data.Direction.normalized * data.Force);
    }
}
