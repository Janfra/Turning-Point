using Extensions;
using System;
using UnityEngine;

public class EntityPoolComponent : PoolComponent<EntityComponent>
{
    public event Action OnEntityReleased;

    [SerializeField]
    private EntityComponent _entityPrefab;

    [Header("Debugger")]
    [SerializeField]
    private LogComponent _logger;

    protected override void OnAwake()
    {
        this.AssertReference(_entityPrefab);
    }

    protected override EntityComponent CreateInstance()
    {
        return Instantiate(_entityPrefab);
    }

    protected override void OnReleasePoolable(EntityComponent obj)
    {
        base.OnReleasePoolable(obj);
        OnEntityReleased.Invoke();
    }
}
