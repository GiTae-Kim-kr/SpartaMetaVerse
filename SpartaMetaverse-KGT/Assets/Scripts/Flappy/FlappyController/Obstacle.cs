using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosition = 1f;  // 장애물 높이 위치
    public float lowPosition = -1f; // 장애물 낮은 위치

    public float holeSizeMin = 1f; // 장애물 사이 구멍 최소 크기
    public float holeSizeMax = 3f; // 장애물 사이 구멍 최대 크기

    public Transform topObstacle; // 위쪽 장애물 위치
    public Transform bottomObstacle; // 아래쪽 장애물 위치

    public float widthPadding = 4f; // 장애물 끼리의 간격

    public Vector3 SetRandomObstacle(Vector3 lastPosition, int obstacleCount)
    {
        
        float randomHoleSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize =  randomHoleSize / 2f;

        float obstacleHeight = topObstacle.GetComponent<SpriteRenderer>().bounds.size.y; // 장애물 높이 가져오기

        
        topObstacle.localPosition = new Vector3(0, halfHoleSize + obstacleHeight / 4.5f, 0);  // 위쪽 장애물 위치를 구멍 크기의 절반만큼 미리 올려놓음
        bottomObstacle.localPosition = new Vector3(0, -halfHoleSize - obstacleHeight / 4.5f, 0);

        Vector3 newPosition = lastPosition + new Vector3(widthPadding, 0, 0);  // 마지막 장애물 위치에서 일정 간격 만큼 떨어진 위치
        newPosition.y = Random.Range(lowPosition, highPosition);   // 장애물 높이를 랜덤으로 설정.

        transform.position = newPosition;  // 장애물 위치 업데이트

        return newPosition;  // 새 장애물 위치를 반환해야 마지막 장애물 위치를 업데이트 할 수 있음.


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlaneController plane = collision.GetComponent<PlaneController>();  // 충돌에서 빠져나간 오브젝트에 PlaneController 스크립트가 컴포넌트로 붙어있는지 확인
        if (plane)
        {
            MiniGameManager.Instance.AddScore(1);  // PlaneController가 있다면 점수를 추가.
        }
    }

}
