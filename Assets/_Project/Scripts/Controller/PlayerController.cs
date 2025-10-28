using Extensions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private ConstantRotationComponent _playerRotation;
    [SerializeField]
    private ShooterComponent _playerShooting;

    [Header("Rotation Settings")]
    [SerializeField]
    private float _defaultRotationSpeed = 200.0f;
    [SerializeField]
    private float _maxRotationSpeed = 250.0f;
    [SerializeField]
    private float _accelerationRate = 2.0f;
    [SerializeField]
    private float _decelerationRate = 2.0f;

    private float _rotationSpeed = 0.0f;
    private bool _isInteracting = false;

    private void Awake()
    {
        this.AssertReference(_playerRotation);
        this.AssertReference(_playerShooting);
    }

    private void Start()
    {
        _playerRotation.SetRotationSpeed(_defaultRotationSpeed);
    }

    private void Update()
    {
        if (_isInteracting) 
        {
            AccelerateRotation();
            _playerRotation.SetRotationSpeed(_rotationSpeed);
        }
        else
        {
            DecelerateRotation();
            _playerRotation.SetRotationSpeed(_rotationSpeed);   
        }
    }

    public void OnInteract()
    {
        _playerRotation.ToggleRotationDirection();
        _playerShooting.Shoot();
        _isInteracting = true;
    }
    
    public void OnEndInteract()
    {
        _isInteracting = false;
    }

    private void AccelerateRotation()
    {
        _rotationSpeed += _accelerationRate * Time.deltaTime;
        _rotationSpeed = Mathf.Min(_rotationSpeed, _maxRotationSpeed);
    }

    private void DecelerateRotation()
    {
        _rotationSpeed -= _decelerationRate * Time.deltaTime;
        _rotationSpeed = Mathf.Max(_rotationSpeed, _defaultRotationSpeed);
    }
}
