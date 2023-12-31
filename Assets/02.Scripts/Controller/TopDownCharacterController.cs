using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{ 
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<Vector2> OnDodgeEvent;
    public event Action<CharacterSO> OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }

    protected CharacterStatsHandler Stats { get; private set; }

    protected virtual void Awake()
    {
        Stats = GetComponent<CharacterStatsHandler>();
    }
    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (Stats.CurrentStats.characterSO == null)
            return;

        if (_timeSinceLastAttack <= Stats.CurrentStats.characterSO.atksp)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        if (IsAttacking && _timeSinceLastAttack > Stats.CurrentStats.characterSO.atksp)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent(Stats.CurrentStats.characterSO);
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    public void CallAttackEvent(CharacterSO characterSO)
    {
        OnAttackEvent?.Invoke(characterSO);
    }

    public void CallDodgeEvent(Vector2 direction)
    {
        OnDodgeEvent?.Invoke(direction);
    }
}
