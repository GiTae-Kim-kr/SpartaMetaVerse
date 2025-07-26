using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5;  // 배경 오브젝트 개수

    public int obstacleCount = 0;   // 장애물 개수
    public Vector3 obstacleLastPosition = Vector3.zero; // 마지막 장애물 위치 초기화 

    private void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();  // 모든 장애물 오브젝트 가져옴
        obstacleCount = obstacles.Length;  // 장애물 개수를 설정
        obstacleLastPosition = obstacles[0].transform.position;  // 첫 번째 장애물 위치를 마지막 장애물 위치로 우선 설정함.

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomObstacle(obstacleLastPosition, obstacleCount);  // 게임 시작시 먼저 모든 장애물 위치를 배치해줌.
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BackGround"))   // 배경과 충돌하면 뒤로 이동시키는 코드
        {
            float widhOfBgObject = ((BoxCollider2D)collision).size.x;  // 배경 오브젝트의 너비 가져옴
            Vector3 pos = collision.transform.position;  // 배경 오브젝트 현재 위치

            pos.x += widhOfBgObject * numBgCount;  // BgLooper랑 충돌하면 배경 오브젝트를 개수만큼 오른쪽으로 이동해서 제일 뒤에 다시 배치되도록 함.
            collision.transform.position = pos;
            return;  // 업데이트 끝
        }


        Obstacle obstacle = collision.GetComponent<Obstacle>();  // 충돌한 오브젝트의 컴포넌트에 Obstacle 스크립트가 있는지 확인
        if (obstacle)  // 스크립트가 있다면
        {
            obstacleLastPosition = obstacle.SetRandomObstacle(obstacleLastPosition, obstacleCount);  // 충돌한 장애물의 위치를 마지막 장애물 위치 뒤에 생성하도록 재배치.
        }
    }

}
