using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{  // 생성한 애니메이션에 대한 메서드를 생성해주고 애니메이터에서 생성한 파라미터 조정하는 스크립트
    private static readonly int IsMoving = Animator.StringToHash("IsMove");   // 성능 최적화 위해서 해시 값으로 변환. 문자열로 비교하면 성능 안좋음
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");
    private static readonly int IsHorseMove = Animator.StringToHash("IsHorseMove");

    protected Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();  // 애니메이션들이 애니메이터에 속해있으니까 InChildren으로 가져옴
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool(IsMoving, obj.magnitude > 0.5f);  // obj.magnitude가 0.5f보다 크면 IsMove 파라미터를 true로 설정하여 이동 애니메이션을 재생
    }// magnitude는 벡터의 크기, 즉 길이를 나타내는데 만약 벡터가 (0,0) 이면 벡터의 크기 magnitude가 0이라는 뜻이라서 이동이 없는 상태라는 것을 나타내는거
    // 그래서 실제로 0.5f라는 값이 유의미한 움직임이 발생하는 지의 구분선이라서 비교를 해준것.

    public void Damage()
    {
        
    }

    public void Ride(bool isRiding)
    {
        animator.SetBool(IsHorseMove, isRiding);
    }




}
