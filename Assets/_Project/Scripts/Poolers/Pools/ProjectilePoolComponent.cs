using Extensions;
using UnityEngine;

public class ProjectilePoolComponent : PoolComponent<ProjectileComponent>
{
    [Header("Instance Settings")]
    [SerializeField]
    private ProjectileComponent projectilePrefab;

    [Header("Debugging")]
    [SerializeField]
    private LogComponent _logger;

    protected override void OnAwake()
    {
        this.AssertReference(projectilePrefab);
    }

    protected override ProjectileComponent CreateInstance()
    {
        return Instantiate(projectilePrefab);
    }

    protected override void OnDestroyPoolable(ProjectileComponent obj)
    {
        base.OnDestroyPoolable(obj);
        _logger?.Log($"ProjectilePoolComponent: Destroyed projectile instance {obj.name}", this);
    }
}
