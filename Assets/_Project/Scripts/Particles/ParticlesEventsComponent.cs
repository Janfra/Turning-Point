using Extensions;
using UnityEngine;
using UnityEngine.Events;

public class ParticlesEventsComponent : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onParticleEnd;

    private void OnParticleSystemStopped()
    {
        _onParticleEnd?.Invoke();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
