using System.Collections;
using System.Collections.Generic;
using Game.Modules.Input;
using Game.Modules.Movement;
using Game.Modules.Stats;
using Game.Player;
using UnityEngine;

public class PlayerMovement
{
    
    #region Fields
    
    private PlayerStats _stats;
    private MovementSystem _movementSystem;

    #endregion
    
    #region Properties

    public float Velocity
    {
        get => _movementSystem.Velocity;
    }
    
    #endregion
    
    #region Constructor/Destructor

    public PlayerMovement(PlayerStats stats)
    {
        _movementSystem = new MovementSystem();
        _stats = stats;

        _movementSystem.IsUsingPortal = true;
    }
    
    #endregion
    
    #region Methods

    public void Update(GameObject obj, InputVars vars)
    {
        Transform objTransform = obj.transform;
        
        //Rotate
        _movementSystem.Rotate(obj.transform, vars.Right, _stats.RotationSpeed);
        
        //Move
        _movementSystem.MoveWithFriction(obj.transform, obj.transform.up, vars.Forward, _stats.Speed, _stats.MaxSpeed, _stats.Friction);
    }
    
    #endregion
    
}
