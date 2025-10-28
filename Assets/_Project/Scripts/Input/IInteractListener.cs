using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace Input
{
    public interface IInteractListener
    {
        public void OnInteract(CallbackContext context);
        public void OnInteractEnd(CallbackContext context);
    }
}
