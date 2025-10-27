using Extensions;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileComponent : MonoBehaviour
{
    private const float SPREAD_FORCE = 220.0f;

    [SerializeField]
    private ToTargetMovementComponent _movementComponent;

    [SerializeField]
    private UnityEvent _onTargetReached;

    [SerializeField]
    private UnityEvent _onKilled;

    ITargetable _target;
    ContactData _contactData;

    private void Awake()
    {
        this.AssertReference(_movementComponent);
    }

    public void SetContactData(ContactData data)
    {
        _contactData = data;
    }

    public void ShootAt(ITargetable target, RotationSegment segment)
    {
        _target = target;
        _movementComponent.Rigidbody.AddForce(GetRandomSpreadForce(segment));
        _movementComponent.SetTarget(target.Transform);
    }

    private Vector2 GetRandomSpreadForce(RotationSegment segment)
    {
        var angleRange = RotationSegments.GetSegmentAngleRange(segment);
        float angle = Random.Range(angleRange.MinAngle, angleRange.MaxAngle);
        float radian = angle * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized * SPREAD_FORCE;
    }

    private void TryDealDamageToTargetable(ITargetable targetable)
    {
        if (_target.TryGetComponent(out IDamageable damageable))
        {
            if (!damageable.TakeDamage(_contactData.Damage))
            {
                _onKilled.Invoke();
            }
        }
    }

    private void ReachedTargetable(ITargetable targetable)
    {
        _contactData.Direction = _movementComponent.Rigidbody.linearVelocity.normalized;
        _target.OnReached(_contactData);
        _onTargetReached?.Invoke();
        TryDealDamageToTargetable(_target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == _target.Transform)
        {
            ReachedTargetable(_target);
            _contactData = new();
        }
    }
}
