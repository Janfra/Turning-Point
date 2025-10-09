using UnityEngine;

public class RotationSegmentProviderComponent : MonoBehaviour
{
    public event System.Action<RotationSegment> OnSegmentChanged;

    [SerializeField]
    private Transform _rotationReference;

    public Vector3 SegmentCenteredDirection => _cachedSegmentCenteredDirection;
    private Vector3 _cachedSegmentCenteredDirection;

    public RotationSegment CurrentSegment => _cachedCurrentSegment;
    private RotationSegment _cachedCurrentSegment;

    private void Update()
    {
        RotationSegment frameSegment = GetRotationAngleAsRotationSegment();
        if (_cachedCurrentSegment != frameSegment)
        {
            _cachedCurrentSegment = frameSegment;
            _cachedSegmentCenteredDirection = GetRotationAsDirection();
            OnSegmentChanged?.Invoke(_cachedCurrentSegment);
        }
    }

    private Vector3 GetRotationAsDirection()
    {
        float angleInRadians = GetSegmentCenterAngleInRadians(_cachedCurrentSegment);
        return new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0);
    }

    private RotationSegment GetRotationAngleAsRotationSegment()
    {
        float angle = _rotationReference.eulerAngles.z;
        return RotationSegments.GetSegmentFromDegrees(angle);
    }

    private float GetSegmentCenterAngleInRadians(RotationSegment segment)
    {
        float angleInDegrees = RotationSegments.GetSegmentCenterAngle(segment);
        return angleInDegrees * Mathf.Deg2Rad;
    }

    private void OnDrawGizmos()
    {
        if (_rotationReference == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, GetRotationAsDirection() * 10);
    }
}
