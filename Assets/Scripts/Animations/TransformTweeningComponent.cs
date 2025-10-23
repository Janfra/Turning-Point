using DG.Tweening;
using Extensions;
using System;
using UnityEngine;

public class TransformTweeningComponent : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private ShakeSettings _defaultShakeSettings;
    private Tweener _cachedTween;

    private void Awake()
    {
        this.AssertReference(_target);
    }

    public void Shake()
    {
        Shake(_defaultShakeSettings);
    }

    public void Shake(ShakeSettings settings)
    {
        if (_cachedTween == null)
        {
            CreateAndCacheTween(settings);
        }
        else
        {
            if (_cachedTween.IsActive() && _cachedTween.IsPlaying())
            {
                _cachedTween.Restart();
            }
            else
            {
                _cachedTween.Kill();
                CreateAndCacheTween(settings);
            }
        }
    }

    private void CreateAndCacheTween(ShakeSettings settings)
    {
        _cachedTween = settings.ApplyShakePositionTo(_target).SetId(this).OnKill(ClearCache);
    }

    private void ClearCache()
    {
        _cachedTween = null;
    }
}

[Serializable]
public struct ShakeSettings
{
    public float Duration;
    public float Strenght;
    public int Vibrato;
    [Range(0f, 180f)]
    public float Randomness;
    public bool Snapping;
    public bool FadeOut;
    public ShakeRandomnessMode RandomnessMode;

    public Tweener ApplyShakePositionTo(Transform transform)
    {
        return transform.DOShakePosition(Duration, Strenght, Vibrato, Randomness, Snapping, FadeOut, RandomnessMode);
    }
}
