using System;
using Game.Modules.IHit;
using Game.Modules.IHit.Handlers;
using Game.Modules.Input;
using Game.Modules.Stats;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Player
{
    public class PlayerView : MonoBehaviour, IHit
    {
    
        #region Fields

        [SerializeField] private TextMeshProUGUI    _speedLbl;
        [SerializeField] private TextMeshProUGUI    _rotAngleLbl;
        [SerializeField] private TextMeshProUGUI    _posLbl;

        [Space(10)]
        [SerializeField] private TextMeshProUGUI    _ammoLbl;
        [SerializeField] private Image              _reloadBar;

        [Space(10)]
        [SerializeField] private Transform          _weaponSocket;
        
        [Space(10)]
        [SerializeField] private PlayerStats        _stats;
        
        private PlayerInputHandler _inputHandler;
        private PlayerMovement _movement;
        private PlayerAttack _attack;
        private HitHandler _hitHandler;

        #endregion
    
        #region Properties
        
    
        #endregion

        #region Unity Callbacks
    
        private void Start()
        {
            _inputHandler = GetComponent<PlayerInputHandler>();
            _hitHandler = new PlayerHitHandler(transform);
            _movement = new PlayerMovement(_stats);
            _attack = new PlayerAttack(_stats, transform, _weaponSocket);
        }
        
        private void FixedUpdate()
        {
            _movement.Update(gameObject, _inputHandler.InputVars);
        }

        private void Update()
        {
            _attack.Update(gameObject, _inputHandler.InputVars);
        }

        private void LateUpdate()
        {
            UpdateUI();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnHit(new HitInfo(other.gameObject, 0, false));
        }

        #endregion
        
        #region Methods

        private void UpdateUI()
        {
            _speedLbl.text = _movement.Velocity.ToString("f2");
            _rotAngleLbl.text = (transform.rotation.eulerAngles.z).ToString("f0") + "°";
            _posLbl.text = transform.position.x.ToString("f0") + ":" + transform.position.y.ToString("f0");

            _ammoLbl.text = _attack.CurrentAmmo.ToString() + " / " + _attack.MaxAmmo.ToString();
            _reloadBar.fillAmount = _attack.ChargeAmount;
        }
        
        public void OnHit(HitInfo info)
        {
            _hitHandler.Handle(info);
        }
        
        #endregion

        
    }
}
