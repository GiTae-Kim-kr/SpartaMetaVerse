using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseController : BaseController
{
    private PlayerController rider = null;

    private void Awake()
    {
        base.Awake();

    }

    protected override void FixedUpdate()
    {
        if (rider != null)
        {
            // 탑승 중일 때 말의 이동을 탑승자의 이동 입력 기반으로 처리.
            Vector2 inputDir = rider.MovementDirection;

            // 속도 조절 등 고유 기능 추가
            Vector2 velocity = inputDir * statHandler.Speed;
            _rigidbody.velocity = velocity;

            // 말 애니메이션 제어
            horseAnimator.SetBool("IsHorseMove", velocity.sqrMagnitude > 0.01f);

            if (inputDir != Vector2.zero)    
                Rotate(inputDir);

            // 플레이어 위치 동기화(말 위에 고정)
            rider.transform.position = transform.position + Vector3.up * 1f;

            JumpPhysicsUpdate();
        }
        else
        {
            // 탑승 중 아닌 상태 기본 이동은 없도록 처리
            _rigidbody.velocity = Vector2.zero;
            horseAnimator.SetBool("IsHorseMove", false);

            base.FixedUpdate();
        }
    }

    public void Mount(PlayerController player)
    {
        rider = player;  // 플레이어를 rider로 설정
        player.IsRiding = true;

        player.transform.position = transform.position + Vector3.up * 1f; // 플레이어 위치를 말 위로 올림
        // 플레이어 Rigidbody 비활성화하거나 제한
        player.GetComponent<Rigidbody2D>().simulated = false;
        // 탑승 시 즉시 위치 동기화
        rider.transform.position = transform.position + Vector3.up * 1f;
    }

    public void Dismount()
    {
        if (rider != null)
        {
            rider.IsRiding = false;  // 플레이어 탑승 상태 해제
            rider.GetComponent<Rigidbody2D>().simulated = true;

            rider.transform.position = transform.position + Vector3.down * 1f; // 플레이어 위치를 말 아래로 내림
            rider = null;
        }
    }


    //public void HorseRide()
    //{
    //    Vector3 horsePos = transform.position;  // 말의 위치 가져옴.

    //    playerController.transform.position = new Vector3(horsePos.x, horsePos.y + 1f, horsePos.z); // 플레이어의 위치를 말의 위치 위로 올려줌. 말의 위치는 Y축이 0이므로, 플레이어는 말 위에 올라가게 됨.
        
    //}

    //public void HorseMove()
    //{
    //    if (playerController != null)
    //    {
    //        Rigidbody2D playerR = playerController.GetComponent<Rigidbody2D>();
    //        if ( playerR != null)
    //        {
    //            _rigidbody.velocity = playerR.velocity;   // 플레이어의 rigidbody 속도와 말의 rigidbody 속도를 같게 설정
                
    //        }
    //    }
    //}


}
