using Extensions;
using UnityEngine;

public class SegmentBasedRotationComponent : MonoBehaviour
{
    [SerializeField]
    private RotationSegmentProviderComponent _segmentProvider;

    private void Awake()
    {
        this.AssertReference(_segmentProvider);
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.AngleAxis(RotationSegments.GetSegmentCenterAngle(_segmentProvider.CurrentSegment), Vector3.forward);
    }
}
