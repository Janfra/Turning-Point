using Extensions;
using UnityEngine;

public class ShooterComponent : MonoBehaviour
{
    [SerializeField]
    private RotationSegmentProviderComponent _directionProvider;
    [SerializeField]
    private SegmentAreasComponent _segmentAreasComponent;
    [SerializeField]
    private ProjectileComponent _projectilePrefab;
    [SerializeField]
    private Transform _aim;
    [SerializeField]
    private ContactData _contactData;

    private void Awake()
    {
        this.AssertReference(_directionProvider);
        this.AssertReference(_segmentAreasComponent);
        this.AssertReference(_projectilePrefab);
        this.AssertReference(_aim);
    }

    public void Shoot()
    {
        RotationSegment segment = _directionProvider.CurrentSegment;
        Collider2D collider = _segmentAreasComponent.GetColliderForSegment(segment);
        Collider2D[] results = new Collider2D[1];
        ContactFilter2D filter = ContactFilter2D.noFilter;
        filter.layerMask = LayerMask.GetMask("Default");
        filter.useLayerMask = true;

        if (Physics2D.OverlapCollider(collider, filter, results) > 0)
        {
            if (results[0].TryGetComponent(out ITargetable targetable))
            {
                targetable.OnTargeted();
                var projectile = Instantiate(_projectilePrefab, transform.position, _aim.rotation);
                projectile.SetContactData(_contactData);    
                projectile.ShootAt(targetable, segment);
            }
        }
    }
}
