using Extensions;
using UnityEngine;

public abstract class AnimatorParameterEvent : ScriptableObject
{
    [SerializeField]
    private AnimatorParameterHasher _parameter;
    public AnimatorParameterHasher Parameter => _parameter;

    public abstract void ApplyEventValue(AnimatorModifierComponent modifierComponent);

    private void OnEnable()
    {
#if UNITY_EDITOR
        if (Application.isPlaying)
        {
            this.AssertReference(_parameter);
        }
#endif
    }
}
