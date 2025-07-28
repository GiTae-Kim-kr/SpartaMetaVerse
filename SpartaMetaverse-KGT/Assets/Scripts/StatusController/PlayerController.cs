using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : BaseController
{
    private Camera camera;
    private GameManager gameManager;

    

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
        camera = Camera.main;
    }


    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized; // 이동 방향을 설정. 방향 벡터로 만들기 위해 normalized를 사용한다.
        // 정확히는 방향 정보만 남기고, 크기를 1로 맞춰주기 위해서인데, 복수의 키 누르면 이동속도가 달라질 수 있어서 해준거임.
    }

    void OnLook(InputValue inputValue)
    {
        Vector2 mousePosition = inputValue.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);      // 마우스의 위치를 월드 좌표로 변환해줘야 한다.
        lookDirection = (worldPos - (Vector2)transform.position);   // 바라보는 방향을 설정해준다. lookDirection도 Vector2고 빼는 대상들도 Vector이다.
                                                                    // 백터의 뺄셈은 두 점(위치) 사이의 방향과 상대 위치를 나타낸다. (목표 위치) - (상대 위치)하면 목표위치까지 향하는 방향 벡터를 구할 수 있다.
        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else lookDirection = lookDirection.normalized;    // 방향 벡터로 만들어줌.
        
    }

    void OnJump(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            if(!isJumping && jumpHeight <= 0f)
            {
                isJumping = true;   // 바닥에 있을 때만 점프하도록 설정함
                jumpVelocity = 0f;    // 점프 시 velocity를 초기화
            }
            
        }
    }

    void OnCommunication(InputValue inputValue)
    {
        if (inputValue.isPressed)  // 키 눌렀을 때
        {
            //Debug.Log("대화 시도");
            if (!isCommunicate)   // 대화 중이 아니라면  (대화를 안하고 있으니 대화를 시도할 수 있겠지)
            {
                //Debug.Log("대화 가능");
                isCommunicate = true;
                
            }
            else
            {
                currentNPC = null;

                uiManager.ChangeState(UIState.None);
            }
        }
    }




}
