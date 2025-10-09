using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static Input.InputSystem_Actions;

namespace Input
{
    public class InputBinder : MonoBehaviour, IPlayerActions, IUIActions
    {
        [SerializeField]
        private UnityEvent _onInteract;

        private InputSystem_Actions _inputActions;
        private PlayerActions _playerActions;
        private UIActions _uiActions;

        private void Awake()
        {
            _inputActions = new InputSystem_Actions();
            _playerActions = _inputActions.Player;
            _uiActions = _inputActions.UI;

            _playerActions.SetCallbacks(this);
            _uiActions.SetCallbacks(this);
        }

        private void OnEnable()
        {
            _playerActions.Enable();
            _uiActions.Enable();
        }

        private void OnDisable()
        {
            _playerActions.Disable();
            _uiActions.Disable();
        }

        public void AddListener(IInteractListener listener)
        {
            _playerActions.Interact.started += listener.OnInteract;
        }

        public void RemoveListener(IInteractListener listener)
        {
            _playerActions.Interact.started -= listener.OnInteract;
        } 

        #region IPlayerActions Interface
        public void OnInteract(InputAction.CallbackContext context)
        {
            // Interact is only valid on started phase
            if (context.started)
            {
                _onInteract?.Invoke();
            }
        }

        public void OnLook(InputAction.CallbackContext context)
        {
           
        }

        public void OnMove(InputAction.CallbackContext context)
        {

        }

        #endregion

        #region IUIActions Interface
        public void OnSubmit(InputAction.CallbackContext context)
        {
            
        }

        public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
        {
            
        }

        public void OnTrackedDevicePosition(InputAction.CallbackContext context)
        {
            
        }

        public void OnNavigate(InputAction.CallbackContext context)
        {
            
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            
        }

        public void OnPoint(InputAction.CallbackContext context)
        {
            
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            
        }

        public void OnRightClick(InputAction.CallbackContext context)
        {
            
        }

        public void OnMiddleClick(InputAction.CallbackContext context)
        {
            
        }

        public void OnScrollWheel(InputAction.CallbackContext context)
        {
            
        }

        #endregion
    }
}
