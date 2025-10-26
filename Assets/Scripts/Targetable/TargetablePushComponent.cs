using System.Collections;
using UnityEngine;

public class TargetablePushComponent : MonoBehaviour, ITargetable
{
    [SerializeField]
    private Rigidbody2D _rigidbody;

    public Transform Transform => transform;

    public void OnTargeted()
    {
        Debug.Log("Targeted Push"); 
    }

    public void OnReached(ContactData data)
    {
        Debug.Log($"Pushed with force: {data.Force} on direction: {data.Direction}");
        _rigidbody.linearVelocity = Vector2.zero;
        _rigidbody.AddForce(data.Direction.normalized * data.Force);
    }
}
