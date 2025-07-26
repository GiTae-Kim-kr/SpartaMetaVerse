using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    Animator animator;
    Rigidbody2D _rigidbody;

    public float forwardSpeed = 5f;
    public float flapForce = 6f;
    float deathCooldown = 0.5f;  // 충돌 후 딜레이 시간

    public bool isDead = false; // 죽었는지 여부
    private bool isFlap = false; // 충돌 여부
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody2D 없음");
        }
        if (animator == null)
        {
            Debug.LogError("Animator 없음");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0f)
            {
                Debug.Log("게임 오버");
            }
            else
            {
                deathCooldown -= Time.deltaTime;  // 딜레이 시간을 감소
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            isFlap = true;
        }

        
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        Vector3 flapDirection = _rigidbody.velocity;  // 현재 속도를 가져옴
        flapDirection.x = forwardSpeed;  // 앞으로 이동하는 속도 설정

        if (isFlap) // 플랩이 활성화되면
        {
            flapDirection.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = flapDirection;  // Rigidbody2D에 새로운 속도 적용

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90); // 점프 속도에 따라 각도를 조절한다.
        transform.rotation = Quaternion.Euler(0, 0, angle);  // Degree 값으로 회전 적용하는거라 Euler 사용했음 

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 뭐든 충돌하면 IsDie를 true로 설정할 거라서 충돌 조건 안정해도 됨.

        if (isDead) return;  // 이미 죽었으면 아무것도 안함

        isDead = true;
        animator.SetInteger("IsDie", 1);  // 애니메이션 상태 죽음으로 변경
        deathCooldown = 1f;  // 충돌 후 딜레이 시간 설정
        MiniGameManager.Instance.GameOver(); //게임 매니저 통해서 게임 오버 처리.
    }

}
