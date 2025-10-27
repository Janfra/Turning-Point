using UnityEngine;

public enum RotationDirection
{
    Clockwise,
    CounterClockwise
}

public class ConstantRotationComponent : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 5f;

    [SerializeField]
    private RotationDirection _rotationDirection = RotationDirection.Clockwise;

    [Header("Debugging")]
    [SerializeField]
    public LogComponent Logger;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(GetRotationAxis(), GetRotationAngleBasedOnDirection());
    }

    public void SetRotationSpeed(float rotationSpeed)
    {
        _rotationSpeed = Mathf.Clamp(rotationSpeed, 0.0f, Mathf.Infinity);
    }

    public void SetRotationDirection(RotationDirection rotationDirection)
    {
        _rotationDirection = rotationDirection;
    }

    public void ToggleRotationDirection()
    {
        _rotationDirection = _rotationDirection == RotationDirection.Clockwise 
            ? RotationDirection.CounterClockwise 
            : RotationDirection.Clockwise;
    }

    private Vector3 GetRotationAxis()
    {
        return Vector3.forward;
    }

    private float GetRotationAngleBasedOnDirection()
    {
        float rotationAngleOverTime = _rotationSpeed * Time.deltaTime;

        switch (_rotationDirection)
        {
            case RotationDirection.Clockwise:
                return -rotationAngleOverTime;
            case RotationDirection.CounterClockwise:
                return rotationAngleOverTime;  
            default:
                Logger?.LogError("Unsupported rotation direction", this);
                return 0.0f;
        }
    }
}
