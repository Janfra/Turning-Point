using UnityEngine;

public abstract class AnimatorParameterEvent : ScriptableObject
{
    [SerializeField]
    private AnimatorParameterHasher _parameter;
    public AnimatorParameterHasher Parameter => _parameter;

    public abstract void ApplyEventValue(AnimatorModifierComponent modifierComponent);
}
