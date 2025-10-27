using Extensions;
using UnityEngine;

public class AudioSourceModifierComponent : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private bool _isLocked = false;

    private void Awake()
    {
        this.AssertReference(_audioSource);
    }

    public void PlayWithRandomPitch(float minPitch, float maxPitch)
    {
        if (!CanPlay())
        {
            return;
        }

        _audioSource.pitch = Random.Range(minPitch, maxPitch);
        _audioSource.Play();
    }

    public void PlayWithRandomPitch(AudioPitchRandomizer pitchRandomizer)
    {
        if (!CanPlay()) 
        {
            return;
        }

        pitchRandomizer.SetRandomPitch(_audioSource);
        _audioSource.Play();
    }

    public void SetAudioLock(bool isLocked)
    {
        _isLocked = isLocked;
    }

    public bool CanPlay()
    {
        return !_isLocked;
    }
}
