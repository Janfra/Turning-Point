using Extensions;
using UnityEngine;

public class AnimatorModifierComponent : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private void Awake()
    {
        this.AssertReference(_animator);
    }

    public void ApplyAnimatorParameterEvent(AnimatorParameterEvent parameterEvent)
    {
        parameterEvent.ApplyEventValue(this);
    }

    public void SetParameterFloat(AnimatorParameterHasher parameter, float value)
    {
        _animator.SetFloat(parameter.ID, value);
    }

    public void SetParameterInt(AnimatorParameterHasher parameter, int value)
    {
        _animator.SetInteger(parameter.ID, value);
    }   

    public void SetParameterBool(AnimatorParameterHasher parameter, bool value)
    {
        _animator.SetBool(parameter.ID, value);
    }

    public void SetParameterTrigger(AnimatorParameterHasher parameter)
    {
        _animator.SetTrigger(parameter.ID);
    }
}