using UnityEngine;
using UnityEngine.Pool;

public abstract class PoolComponent<T> : MonoBehaviour where T : Component, IPoolable<T>
{
    [Header("Pool Settings")]
    [SerializeField]
    private bool _collectionCheck = true;
    [SerializeField]
    private int _defaultCapacity = 10;
    [SerializeField]
    private int _maxSize = 100;

    protected ObjectPool<T> _Pool => _pool;
    private ObjectPool<T> _pool;

    private void OnValidate()
    {
        _defaultCapacity = Mathf.Max(0, _defaultCapacity);
        _maxSize = Mathf.Max(1, _maxSize);
    }

    private void Awake()
    {
        _pool = new(OnCreatePoolable, OnGetPoolable, OnReleasePoolable, OnDestroyPoolable, _collectionCheck, _defaultCapacity, _maxSize);
    }

    public T Get()
    {
        return _pool.Get();
    }

    public T Get(Vector3 position, Quaternion rotation)
    {
        T obj = _pool.Get();
        obj.transform.SetPositionAndRotation(position, rotation);
        return obj;
    }

    public void Release(T obj)
    {
        _pool.Release(obj);
    }

    protected abstract T CreateInstance();

    protected virtual void OnAwake() { }

    protected T OnCreatePoolable()
    {
        T obj = CreateInstance();
        if (obj == null)
        {
            Debug.LogError($"PoolComponent<{typeof(T).Name}>: CreateInstance returned null. Make sure to implement CreateInstance properly.");
            return null;
        }

        obj.Pool = _pool;
        return obj;
    }

    protected virtual void OnGetPoolable(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    protected virtual void OnReleasePoolable(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    protected virtual void OnDestroyPoolable(T obj)
    {
        Destroy(obj.gameObject);
    }
}
