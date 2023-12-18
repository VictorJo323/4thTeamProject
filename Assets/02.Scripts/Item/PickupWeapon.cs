using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    public ItemSO weaponData;
    public GameObject weaponPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 플레이어의 WeaponInventory 컴포넌트를 찾습니다.
            WeaponInventory playerWeapon = collision.GetComponent<WeaponInventory>();

            if (playerWeapon != null)
            {
                GameObject weaponObject = Instantiate(weaponPrefab, playerWeapon.transform.position, Quaternion.identity);

                Weapon weaponComponent = weaponObject.GetComponent<Weapon>();

                weaponComponent.weaponData = weaponData;

                playerWeapon.AddWeapon(weaponComponent);

                gameObject.SetActive(false);
            }
        }
    }
}
