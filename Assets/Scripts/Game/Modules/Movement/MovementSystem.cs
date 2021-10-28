using UnityEngine;

namespace Game.Modules.Movement
{
    public class MovementSystem
    {
        
        #region Fields
        
        private Vector3 _currentVelocity = Vector3.zero;
        private Vector3 _lastVelocity = Vector3.zero;

        private Camera _mainCamera;
        
        #endregion
        
        #region Properties

        public bool IsUsingPortal
        {
            get;
            set;
        }

        public float Velocity
        {
            get => _currentVelocity.magnitude;
        }
        
        #endregion
        
        #region Constructor

        public MovementSystem()
        {
            _mainCamera = Camera.main;

            IsUsingPortal = false;
        }
        
        #endregion
        
        #region Methods
        
        /**
         * Returns true - OK
         * Returns false - object outside of map and not using portal
         */
        public bool MoveWithFriction(Transform objTransform, Vector3 dir, float forward, float speed, float maxSpeed, float friction)
        {
            //Calculate velocity
            _lastVelocity = _currentVelocity;
            _currentVelocity = dir * forward * Time.fixedDeltaTime * speed;

            _currentVelocity += _lastVelocity;
            _currentVelocity = Vector3.ClampMagnitude(_currentVelocity, maxSpeed);
            _currentVelocity *= friction;
        
            var localPosition = objTransform.localPosition;
            Vector3 desiredPos = _currentVelocity + localPosition;

            objTransform.localPosition = Vector3.Lerp(localPosition, desiredPos, 0.1f);
            
            return HandlePortal(objTransform);
        }
        
        /**
         * Returns true - OK
         * Returns false - object outside of map and not using portal
         */
        public bool Move(Transform objTransform, Vector3 dir, float forward, float speed, float maxSpeed)
        {
            _currentVelocity = dir * forward * Time.deltaTime * speed;
            _currentVelocity = Vector3.ClampMagnitude(_currentVelocity, maxSpeed);
            
            var localPosition = objTransform.localPosition;
            Vector3 desiredPos = _currentVelocity + localPosition;

            objTransform.localPosition = Vector3.Lerp(localPosition, desiredPos, 0.1f);
            
            return HandlePortal(objTransform);
        }

        public void Rotate(Transform objTransform, float right, float rotationSpeed)
        {
            objTransform.Rotate(objTransform.forward, -right  * rotationSpeed);
        }

        public void RotateToPoint(Transform objTransform, Vector3 target)
        {
            var dir = target - objTransform.position;
            var angle =  Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            objTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private bool HandlePortal(Transform objTransform)
        {
            //Portal mapping
            if (_mainCamera != null)
            {
                Vector3 viewportPoint = _mainCamera.WorldToViewportPoint(objTransform.position);
        
                if ((viewportPoint.x >= 1.1 || viewportPoint.x <= -0.1f) && (viewportPoint.y >= 1.1 || viewportPoint.y <= -0.1f))
                {
                    if (IsUsingPortal)
                    {
                        viewportPoint.x = (viewportPoint.x >= 1.1f) ? 0.0f : 1.0f;
                        viewportPoint.y = (viewportPoint.y >= 1.1f) ? 0f : 1.0f;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (viewportPoint.y >= 1.1 || viewportPoint.y <= -0.1f)
                {
                    if (IsUsingPortal)
                    {
                        viewportPoint.y = (viewportPoint.y >= 1.1f) ? 0f : 1.0f;
                        viewportPoint.x -= viewportPoint.x - 0.5f;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (viewportPoint.x >= 1.1 || viewportPoint.x <= -0.1f)
                {
                    if (IsUsingPortal)
                    {
                        viewportPoint.x = (viewportPoint.x >= 1.1f) ? 0.0f : 1.0f;
                        viewportPoint.y -= viewportPoint.y - 0.5f;
                    }
                    else
                    {
                        return false;
                    }
                }
        

                objTransform.position = _mainCamera.ViewportToWorldPoint(viewportPoint);
            }

            return true;
        }
        
        #endregion
        
    }
}


