using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    // Start is called before the first frame update
    private Camera _camera;
    public float dodgeDistance = 2f;
    public float dodgeSpeed = 10f;
    StaminaSystem StaminaSystem;
    

    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
        StaminaSystem = GetComponent<StaminaSystem>();
    }

    public void OnMove(InputValue value)
    {
        //Debug.Log("OnMove"+value.ToString());
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
    public void OnLook(InputValue value)
    {
        //Debug.Log("OnLook" + value.ToString());
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }
    }
    public void OnFire(InputValue value)
    {
        //Debug.Log("OnFire" + value.ToString());
        IsAttacking = value.isPressed;
    }
    
    public void OnDodge()
    {
        if (StaminaSystem.CurrentStamina > StaminaSystem.amount) 
        {
            
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);   //마우스 위치를 받아서 월드포인트 좌표로 변경 / 해당 위치를 마우스포지션에 저장
            Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;      // 마우스위치 - 캐릭터 위치의 벡터 정규화 (1)
            Vector2 targetPosition = (Vector2)transform.position + direction * dodgeDistance;  //  타겟 (목표지점)을 캐릭터 위치 + 방향의 벡터 정보를 더하고 회피 거리만큼으로 결정
            StartCoroutine(MoveToSpot(targetPosition));     // MoveToSpot 함수 실행
        }
        
    }
    public IEnumerator MoveToSpot(Vector2 targetPosition)
    {
        float elapsedTime = 0;
        float waitTime = dodgeDistance / dodgeSpeed;   //총 이동하는 시간은 속력과 거리에 의해 결정되므로
        Vector2 startPosition = transform.position;      // 이 스크립트가 붙어 있는 캐릭터의 위치가 스타트 포인트
        while (elapsedTime < waitTime)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, (elapsedTime / waitTime));   //스타트포지션에서 타겟포지션까지, elapsedTime/waitTime의 정도로 선형보간
            elapsedTime += Time.deltaTime;      // 시간에 deltaTime 더함.
            yield return null;       // 연속적인 동작의 수행이므로! return null 시 한번 실행 후 바로 while을 탈출해버림.
            
        }
        
        transform.position = targetPosition;      // 포지션을 타겟포지션으로 변경
        
    }
}