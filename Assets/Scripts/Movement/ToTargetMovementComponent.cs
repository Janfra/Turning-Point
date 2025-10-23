using Extensions;
using UnityEngine;

public class ToTargetMovementComponent : MovementComponent
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _acceleration = 0.1f;

    protected override void OnAwake()
    {
        this.AssertReference(_target);
    }

    protected override void Move()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        if (!CanAccelerateOnDirection(direction))
        {
            return;
        }

        _Rigidbody.AddForce(direction * _acceleration);
    }

    private bool CanAccelerateOnDirection(Vector3 direction)
    {
        Vector3 currentDirection = _Rigidbody.linearVelocity.normalized;
        bool isSimilarDirection = Vector3.Dot(currentDirection, direction) > 0.9; // Will continue to accelerate if moving in a similar direction
        bool isBelowSpeedLimit = _Rigidbody.linearVelocity.sqrMagnitude < _MaxSpeed * _MaxSpeed;
        return !isSimilarDirection || isBelowSpeedLimit;
    }
}
