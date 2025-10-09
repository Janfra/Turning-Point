using UnityEngine;

public class ShooterComponent : MonoBehaviour
{
    [SerializeField]
    private RotationSegmentProviderComponent _directionProvider;

    public void Shoot()
    {
        Physics2D.Raycast(transform.position, _directionProvider.SegmentCenteredDirection);
    }
}
