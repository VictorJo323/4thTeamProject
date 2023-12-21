using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackController : MonoBehaviour
{
    public WeaponInventory weaponInventory;
    public LayerMask enemyLayer; // 적 레이어 마스크
    private float attackRadius; // 공격 범위
    private float attackCooldown = 0f;
    private float lastAttackTime;
    public ParticleSystem attackTrailEffect;
    public RangedAttackController rangedAttackController;


    private void Update()
    {
        if (attackCooldown > 0f)
        {
            attackCooldown -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && attackCooldown <= 0f)
        {
            ItemSO currentWeaponData = weaponInventory.GetWeaponInUse();
            if (currentWeaponData != null)
            {
                if (currentWeaponData.itemType == Type.MeleeWeapon)
                {
                    PerformMeleeAttack(currentWeaponData);
                    attackCooldown = 2.5f / currentWeaponData.atksp; // 공격 속도에 따른 쿨타임 설정
                    lastAttackTime = Time.time;
                }
                else if (currentWeaponData.itemType == Type.RangedWeapon)
                {
                    Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
                    //rangedAttackController.InitializeAttack(direction, currentWeaponData.rangedAttackData, /* ProjectileManager 인스턴스 */);

                }
            }
        }
    }

    private void PerformMeleeAttack(ItemSO weaponData)
    {
        attackRadius = weaponData.atkRange;
        Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 파티클 시스템의 위치와 회전 설정
        attackTrailEffect.transform.position = transform.position;
        attackTrailEffect.transform.rotation = Quaternion.Euler(0, 0, angle-45); // Cone을 위한 각도 조정

        // 파티클의 Shape 모듈 설정
        var shape = attackTrailEffect.shape;
        //shape.shapeType = ParticleSystemShapeType.;
        shape.angle = 50; // Cone의 각도 (100도 범위를 커버하기 위해 50도 설정)
        shape.radius = weaponData.atkRange; // Cone의 반경

        // 파티클 효과 실행
        attackTrailEffect.Play();

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRadius, enemyLayer);
        foreach (Collider2D hit in hits)
        {
            Vector2 hitDirection = hit.transform.position - transform.position;
            float hitAngle = Mathf.Atan2(hitDirection.y, hitDirection.x) * Mathf.Rad2Deg;
            if (Mathf.Abs(Mathf.DeltaAngle(angle, hitAngle)) <= 60)
            {
                Debug.Log(hit.gameObject.name + " hit!");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // 공격 범위 시각화 (편집기에서만 보임)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}

