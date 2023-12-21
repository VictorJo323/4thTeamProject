using Cainos.PixelArtTopDown_Basic;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Shooting : MonoBehaviour
{
    private TopDownCharacterController _controller;

    [SerializeField] private Transform projectileSpawnPosition;
    // [SerializeField] private Transform projectileSpawnPositionR;
    [SerializeField] private Transform playerTransform;

    private Vector2 _aimDirection = Vector2.right;

    private ProjectileManager _projectileManager;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    { 
        _projectileManager = ProjectileManager.instance;
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;
    }

    private void OnShoot(CharacterSO characterSO)
    {
        RangedAttackData rangedAttackData = characterSO as RangedAttackData;
        float projectilesAngleSpace = rangedAttackData.multipleProjectilesAngel;
        int numberOfProjectilesPerShot = rangedAttackData.numberofProjectilesPerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackData.multipleProjectilesAngel;


        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + projectilesAngleSpace * i;
            float randomSpread = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
            angle += randomSpread;
            CreateProjectile(rangedAttackData, angle);

            //if (isTwo)
            //{
            //    CreateProjectileTwo(rangedAttackData, angle);
            //}    
        }
    }

    private void CreateProjectile(RangedAttackData rangedAttackData, float angle)
    {
        _projectileManager.ShootBullet(
                projectileSpawnPosition.position,
                RotateVector2(_aimDirection, angle),
                rangedAttackData
                );
    }

    //private void CreateProjectileTwo(RangedAttackData rangedAttackData, float angle)
    //{
    //    _projectileManager.BerserkShoot(
    //            projectileSpawnPositionR.position,
    //            RotateVector2(_aimDirection, angle),
    //            rangedAttackData
    //            );
    //}

    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }
}
