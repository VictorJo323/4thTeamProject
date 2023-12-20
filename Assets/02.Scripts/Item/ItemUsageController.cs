using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUsageController : MonoBehaviour
{
    public ConsumableInventory consumableInventory;
    private float healthPotionCooldown = 15f;
    private bool canUseHealthPotion = true;

    public void UseHealthPotion(int healthRecoveryAmount)
    {
        if (canUseHealthPotion && consumableInventory.UseHealthPotion())
        {
            // 체력 회복 로직
            Debug.Log($"Recovered {healthRecoveryAmount} health.");
            StartCoroutine(HealthPotionCooldown());
        }
    }

    private IEnumerator HealthPotionCooldown()
    {
        canUseHealthPotion = false;
        yield return new WaitForSeconds(healthPotionCooldown);
        canUseHealthPotion = true;
    }

    // 기타 아이템 사용 메서드...
}