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

    protected bool isCommunicate = false;   // 대화중인지.
    protected bool isJumping = false;   // 점프 상태 관리
    protected float jumpHeight = 0f;                 // 공중에 떠 있는 높이
    protected float jumpVelocity = 0f;               // 높이 변화 속도
    protected float gravity = -70f;                  // 가상의 중력 값
    protected float initialJumpVelocity = 30f;       // 초기 점프 강도

    protected CollisionSensor collisionSensor;
    protected NpcController npcController;


    [Header("NPC 상호작용")]
    [SerializeField] private LayerMask levelCollisionLayer;    // 레이어 설정
    [Range(0f, 20f)][SerializeField] protected float radius;
    public float Radius
    {
        get => radius;
        set => radius = Mathf.Clamp(value, 1f, 20f);
    }

    protected INPC currentNPC = null;


    protected virtual void Awake()
    {
        
        _rigidbody = GetComponent<Rigidbody2D>();    // 이거 불러와줘야 velocity의 값이 전달됨
        animHandler = GetComponent<AnimationHandler>();
        animator = GetComponentInChildren<Animator>();
        statHandler = GetComponent<StatHandler>();
        collisionSensor = GetComponent<CollisionSensor>();
        npcController = GetComponentInChildren<NpcController>();
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
        JumpPhysicsUpdate();
        Communicate();

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

    protected void JumpPhysicsUpdate()   // 점프에 대한 물리 처리 메서드
    {
        // 바닥과 닿아있는지 여부를 판단하는 bool 값. 바닥에 닿아있으면 true 값 반환.
        bool isGrounded = jumpHeight <= 0f;      // 점프 높이가 0이면 바닥에 닿아 있다.

        if (isJumping)
        {
            // 점프 시작 시점에서만 jumpVelocity 초기화
            if (jumpVelocity == 0f)
            {
                jumpVelocity = initialJumpVelocity;
            }

            jumpVelocity += gravity * Time.fixedDeltaTime;  // 시간 지날수록 점점 점프 속도 느려지게 설정
            jumpHeight += jumpVelocity * Time.fixedDeltaTime;   // 점프 속도로 점프 높이 구하기 때문

            //바닥에 도달하면 착지처리
            if (jumpHeight < 0f)
            {
                jumpHeight = 0f;
                jumpVelocity = 0f;
                isJumping = false;
            }
        }

        if (_spriteRenderer != null)
        {
            Vector3 basePosition = transform.position;  // 2D이므로 원래 transform.position은 Rigidbody(x,y) 이므로, z는 0이거나 고정이어야 함.
            // 다만 여기선 jumpHeight 를 Y축이나 z축에 변환해 줘야 해서 Vector3로 위치 값 받아옴.

            _spriteRenderer.transform.localPosition = new Vector3(0, jumpHeight * 0.1f, 0);  // 0.1f는 높이 조절을 위해 그냥 붙여준 스케일링 상수

        }
    }

    protected void Communicate()
    {
        if (isCommunicate)
        {
            //Debug.Log("대화 시작");
            CommunicateNPC();
            if (currentNPC != null)
            {
                //Debug.Log("대화 중");
                currentNPC.Talk();  // 대화 중이면 현재 NPC와 대화
                isCommunicate = false;  // 대화 끝나면 false

            }
            else
            {
                //Debug.Log("대화 가능한 NPC 없음");
                isCommunicate = false; 
            }
        }
    }

    protected void CommunicateNPC()
    {
        // 충돌 감지
        Vector2 center = transform.position;
        int npcLayerMask = LayerMask.GetMask("NPC");
        Collider2D[] nearbyNPC = Physics2D.OverlapCircleAll(center, radius, npcLayerMask);
        //Debug.Log($"탐지된 NPC 수: {nearbyNPC.Length}, radius: {radius}");

        Collider2D closetNPC = null;
        float minDistance = Mathf.Infinity;  // 무한대로 초기화

        foreach (var collider in nearbyNPC)
        {
            float dist = Vector2.Distance(center, collider.transform.position);  // 현재 플레이어와 NPC 사이의 거리를 계산
            //Debug.Log($"NPC 이름: {collider.name}, 거리: {dist}");
            if (dist < minDistance)  // 만약 현재 NPC가 가장 가까운 NPC라면
            {
                minDistance = dist;
                closetNPC = collider;
            }
        }

        if (closetNPC != null)
        {
            INPC npc = closetNPC.GetComponent<INPC>();  // 가장 가까운 NPC가 대화 가능한 NPC인지 확인
            if (npc != null)
            {
                currentNPC = npc;  // 대화 가능한 NPC를 현재 NPC로 설정
                //Debug.Log("가장 가까운 NPC 발견!");
            }
            else
            {
                //Debug.Log("가장 가까운 NPC는 INPC 미구현");
                currentNPC = null;
            }

        }
        else
        {
            currentNPC = null;
        }
    }

}
