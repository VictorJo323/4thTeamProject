using System;
using UnityEngine;
using UnityEngine.UI;

public class StamianSystem : MonoBehaviour
{
    private CharacterStatsHandler _statsHandler;
    public float amount = 20f;
    private PlayerInputController _playerInputController;

    public Image uiBar;
    public float recoveryRate = 5f;

    public float CurrentStamina { get; private set; }
    public float MaxStamina => _statsHandler != null ? _statsHandler.CurrentStats.maxStamina : 0f;
        
    public float recoveryInterval = 1f;

    private void Awake()
    {
        _statsHandler = GetComponent<CharacterStatsHandler>();        
        CurrentStamina = MaxStamina; // ���¹̳� �ʱⰪ ����
        
    }

    private void Update()
    {
        UpdateStamina();
        if (uiBar != null) // UI �ٰ� �Ҵ�Ǿ� �ִ� ��쿡�� ������Ʈ
            uiBar.fillAmount = GetPercentage();
        
        
        if (Input.GetKeyDown(KeyCode.LeftShift)&&CanUseDodge())
        {
            UseStaminaForDodge();
        }
    }

    private void UpdateStamina()
    {
        if (CurrentStamina < MaxStamina)
        {
            float recoveryAmount = recoveryRate * Time.deltaTime;
            CurrentStamina = Mathf.Min(CurrentStamina + recoveryAmount, MaxStamina);
        }
    }

    public bool UseStamina()
    {
        if (CurrentStamina >= amount)
        {
            CurrentStamina -= amount;

            float recoveryAmount = recoveryRate * Time.deltaTime;
            CurrentStamina = Mathf.Min(CurrentStamina + recoveryAmount, MaxStamina);
            return true;
        }
        return false;
    }

    public void RecoverStamina()
    {
        if (CurrentStamina < MaxStamina)
        {
            float recoveryAmount = recoveryRate * Time.deltaTime;
            CurrentStamina = Mathf.Min(CurrentStamina + recoveryAmount, MaxStamina);
        }
    }
    public bool CanUseDodge()
    {
        return CurrentStamina >= amount; 
    }

    public bool UseStaminaForDodge()
    {
        if (CanUseDodge())
        {
            UseStamina(); 
            _playerInputController.OnDodge();
            return true;
        }
        else
        {
            
            return false;
        }
    }

    public float GetPercentage()
    {
        return CurrentStamina / MaxStamina;
    }

    
    
}