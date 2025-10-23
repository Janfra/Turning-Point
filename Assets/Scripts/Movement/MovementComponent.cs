using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class MovementComponent : MonoBehaviour
{
    public bool IsActive = true;

    [SerializeField]
    protected Rigidbody2D _Rigidbody;

    [SerializeField]
    protected float _MaxSpeed = 1.0f;

    private void Awake()
    {
        if (_Rigidbody == null)
        {
            _Rigidbody = GetComponent<Rigidbody2D>();
        }

        OnAwake();
    }

    protected void FixedUpdate()
    {
        if (IsActive)
        {
            Move();
        }    

        OnFixedUpdate();
    }

    protected abstract void Move();

    protected virtual void OnAwake() { }

    protected virtual void OnFixedUpdate() { }
}
