using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackController : MonoBehaviour
{
    public WeaponInventory weaponInventory;
    public LayerMask enemyLayer; // �� ���̾� ����ũ
    private float attackRadius; // ���� ����
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
                    attackCooldown = 2.5f / currentWeaponData.atksp; // ���� �ӵ��� ���� ��Ÿ�� ����
                    lastAttackTime = Time.time;
                }
                else if (currentWeaponData.itemType == Type.RangedWeapon)
                {
                    Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
                    //rangedAttackController.InitializeAttack(direction, currentWeaponData.rangedAttackData, /* ProjectileManager �ν��Ͻ� */);

                }
            }
        }
    }

    private void PerformMeleeAttack(ItemSO weaponData)
    {
        attackRadius = weaponData.atkRange;
        Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ��ƼŬ �ý����� ��ġ�� ȸ�� ����
        attackTrailEffect.transform.position = transform.position;
        attackTrailEffect.transform.rotation = Quaternion.Euler(0, 0, angle-45); // Cone�� ���� ���� ����

        // ��ƼŬ�� Shape ��� ����
        var shape = attackTrailEffect.shape;
        //shape.shapeType = ParticleSystemShapeType.;
        shape.angle = 50; // Cone�� ���� (100�� ������ Ŀ���ϱ� ���� 50�� ����)
        shape.radius = weaponData.atkRange; // Cone�� �ݰ�

        // ��ƼŬ ȿ�� ����
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
        // ���� ���� �ð�ȭ (�����⿡���� ����)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}

