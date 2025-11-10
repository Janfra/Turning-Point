using UnityEngine;
using UnityEngine.Pool;

public class EntityComponent : MonoBehaviour, IPoolable<EntityComponent>
{
    [SerializeField]
    private ToTargetMovementComponent _movementComponent;
    [SerializeField]
    private HealthComponent _healthComponent;

    #region IPoolable 
    public IObjectPool<EntityComponent> Pool { get => _pool; set => _pool = value; }
    private IObjectPool<EntityComponent> _pool;

    public void ReleaseToPool()
    {
        Pool?.Release(this);
    }
    #endregion

    public void SetTarget(Transform transform)
    {
        _movementComponent.SetTarget(transform);
    }
}
