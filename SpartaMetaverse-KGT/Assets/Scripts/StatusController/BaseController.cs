using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    // 전반적으로 공통적으로 가지고 있는 움직임 들을 다루는 추상 스크립트
    // 1. 이동관련  2. 공격관련
    // 이동 관련해서 필요한것? 1. 스프라이트 모습 가져와야함.
    [SerializeField] private SpriteRenderer _spriteRenderer;
    protected Vector2 movementDirection = Vector2.zero;  // 대상의 이동 방향 벡터
    public Vector2 MovementDirection { get { return movementDirection; } }   // 프로퍼티

    protected Vector2 lookDirection = Vector2.right;  // 바라보는 방향 벡터 (시선), 초기값은 오른쪽
    public Vector2 LookDirection { get { return lookDirection; } }  // 쉽게 접근하기 위한 프로퍼티

    protected AnimationHandler animHandler;
    protected Animator animator;
    protected StatHandler statHandler;

    private static readonly int IsJump = Animator.StringToHash("IsJump");

    protected bool isJumping;

    protected virtual void Awake()
    {
        
        _rigidbody = GetComponent<Rigidbody2D>();    // 이거 불러와줘야 velocity의 값이 전달됨
        animHandler = GetComponent<AnimationHandler>();
        animator = GetComponentInChildren<Animator>();
        statHandler = GetComponent<StatHandler>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
 
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);    // 이동 방향 벡터 넣어줌
        Rotate(lookDirection);
        
        
    }

    private void Movement(Vector2 direction)
    {  // 이동 방향에 대한 벡터값을 받아서 움직임에 부가요소들을 설정해줌  // 모든 옵젝의 움직임에 대한 메서드
       // 예를 들면 이동속도, 넉백, 그런 움직임들
        direction = direction * statHandler.Speed; // 방향벡터에 힘을 곱해줘서 속도 값을 부여해줌
        _rigidbody.velocity = direction;    // rigidbody의 속도에 direction값 부여해줌

        animHandler.Move(direction);        // 이동 애니메이션 

    }

    private void Rotate(Vector2 direction)
    {   // 입력받은 방향 벡터의 좌표를 계산해서 회전 각도를 알아내는 메서드
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;  // Mathf.Atan2 아크탄젠트2는 주어진 좌표로부터 각도(라디안)을 계산한다.
                                                                             // Mathf.Rad2Deg 는 라디안 투 디그리라는 뜻으로, 각도(라디안) => 각도(도) 로 변환
        bool isLeft = Mathf.Abs(rotz) > 90f;    // 90도 보다 크면 왼쪽 방향

        if (isLeft)
        {
            _spriteRenderer.flipX = true;
        }
        else _spriteRenderer.flipX = false;

    }

    


}
