using UnityEngine;

[CreateAssetMenu(fileName = "AudioPitchRandomizer", menuName = "Scriptable Objects/Audio/Audio Pitch Randomizer")]
public class AudioPitchRandomizer : ScriptableObject
{
    [SerializeField, Range(-3, 3)]
    private float _minPitch = 1.0f;
    public float MinPitch => _minPitch;

    [SerializeField, Range(-3, 3)]
    private float _maxPitch = 1.0f;
    public float MaxPitch => _maxPitch;

    public void SetRandomPitch(AudioSource audioSource)
    {
        audioSource.pitch = Random.Range(_minPitch, _maxPitch);
    }

    private void SwapPitchRange()
    {
        float temp = _minPitch;
        _minPitch = _maxPitch;
        _maxPitch = temp;
    }

    private void OnValidate()
    {
        if (_minPitch > _maxPitch || _maxPitch < _minPitch)
        {
            SwapPitchRange();
        }
    }
}
