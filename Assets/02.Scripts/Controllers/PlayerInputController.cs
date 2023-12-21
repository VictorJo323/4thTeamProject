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
            
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);   //���콺 ��ġ�� �޾Ƽ� ��������Ʈ ��ǥ�� ���� / �ش� ��ġ�� ���콺�����ǿ� ����
            Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;      // ���콺��ġ - ĳ���� ��ġ�� ���� ����ȭ (1)
            Vector2 targetPosition = (Vector2)transform.position + direction * dodgeDistance;  //  Ÿ�� (��ǥ����)�� ĳ���� ��ġ + ������ ���� ������ ���ϰ� ȸ�� �Ÿ���ŭ���� ����
            StartCoroutine(MoveToSpot(targetPosition));     // MoveToSpot �Լ� ����
        }
        
    }
    public IEnumerator MoveToSpot(Vector2 targetPosition)
    {
        float elapsedTime = 0;
        float waitTime = dodgeDistance / dodgeSpeed;   //�� �̵��ϴ� �ð��� �ӷ°� �Ÿ��� ���� �����ǹǷ�
        Vector2 startPosition = transform.position;      // �� ��ũ��Ʈ�� �پ� �ִ� ĳ������ ��ġ�� ��ŸƮ ����Ʈ
        while (elapsedTime < waitTime)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, (elapsedTime / waitTime));   //��ŸƮ�����ǿ��� Ÿ�������Ǳ���, elapsedTime/waitTime�� ������ ��������
            elapsedTime += Time.deltaTime;      // �ð��� deltaTime ����.
            yield return null;       // �������� ������ �����̹Ƿ�! return null �� �ѹ� ���� �� �ٷ� while�� Ż���ع���.
            
        }
        
        transform.position = targetPosition;      // �������� Ÿ������������ ����
        
    }
}