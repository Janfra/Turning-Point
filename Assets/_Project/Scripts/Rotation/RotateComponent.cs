using Extensions;
using UnityEngine;

public class RotateComponent : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        this.AssertReference(_rigidbody);
    }

    private void Update()
    {
        RotateTransformToAlignWithVelocity();
    }

    private void RotateTransformToAlignWithVelocity()
    {
        Vector2 velocity = _rigidbody.linearVelocity.normalized;
        if (Mathf.Approximately(velocity.sqrMagnitude, 0.0f))
        {
            return;
        }

        transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * Mathf.Atan2(velocity.y, velocity.x), Vector3.forward);
    }
}
