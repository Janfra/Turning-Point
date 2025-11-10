using Extensions;
using System;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    [SerializeField]
    private EntityPoolComponent _entityPool;
    [SerializeField]
    private Transform _target;

    [Header("Spawn Configuration")]
    [SerializeField]
    private RandomRectanglePerimeterPosition _perimeterPositionGetter;

    [Tooltip("When enemy is returned to pool, will spawn again if under this value are active")]
    public int MinActive;

    private void Awake()
    {
        this.AssertReference(_entityPool);
        this.AssertReference(_target);
    }

    private void Start()
    {
        Spawn(MinActive);
    }

    private void OnEnable()
    {
        _entityPool.OnEntityReleased += CheckForMinimumActive;
    }

    private void OnDisable()
    {
        _entityPool.OnEntityReleased -= CheckForMinimumActive;
    }

    public void Spawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        Vector2 spawnPoint = _perimeterPositionGetter.GetRandomPosition();
        Vector2 facingDirection = (Vector2)_target.position - spawnPoint;
        EntityComponent entity = _entityPool.Get(spawnPoint, Quaternion.AngleAxis(Mathf.Atan2(facingDirection.y, facingDirection.x), Vector3.forward));
        entity.SetTarget(transform);
    }

    private void CheckForMinimumActive()
    {
        if (_entityPool.ActiveCount < MinActive)
        {
            Spawn();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position, _perimeterPositionGetter.Size);
    }
}
