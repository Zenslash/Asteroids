using Game.Modules.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
    
        #region Fields
        
        private InputVars _inputVars;
    
        #endregion
        
        #region Property

        public InputVars InputVars
        {
            get => _inputVars;
        }
        
        #endregion
    
        #region Unity Callbacks

        private void Awake()
        {
            _inputVars = new InputVars();
        }

        #endregion
    
        #region Input Callbacks
    
        public void Move(InputAction.CallbackContext context)
        {
            _inputVars.Forward = context.ReadValue<float>();
        }
    
        public void Fire(InputAction.CallbackContext context)
        {
            _inputVars.Fire = context.ReadValue<float>();
        }
    
        public void Look(InputAction.CallbackContext context)
        {
            _inputVars.Right = context.ReadValue<float>();
        }
    
        #endregion
    
    }
}
