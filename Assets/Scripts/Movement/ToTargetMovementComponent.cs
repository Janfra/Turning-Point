using Extensions;
using UnityEngine;
using UnityEngine.Events;

public class ToTargetMovementComponent : MovementComponent
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _acceleration = 0.1f;

    [SerializeField]
    private UnityEvent _onTargetLost;

    public void SetTarget(Transform target, bool activate = true)
    {
        _target = target;
        if (activate && _target)
        {
            IsActive = true;
        }
    }

    protected override void OnAwake()
    {
        if (_target == null)
        {
            IsActive = false;
        }
    }

    protected override void Move()
    {
        if (_target == null || !_target.gameObject.activeSelf)
        {
            HandleTargetLost();
            return;
        }

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

    private void HandleTargetLost()
    {
        IsActive = false;
        _onTargetLost.Invoke();
    }
}
