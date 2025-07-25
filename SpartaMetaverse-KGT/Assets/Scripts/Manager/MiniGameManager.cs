using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] private List<Rect> miniGameAreas;  // 미니게임 영역 리스트
    [SerializeField] private Color gizmoColor = new Color(1, 0, 0, 0.3f);

    private PlayerController playerController;
    private bool gameStarted = false;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnDrawGizmos()
    {
        if (miniGameAreas == null) return;

        Gizmos.color = gizmoColor;
        foreach (var area in miniGameAreas)
        {
            Vector3 center = new Vector3(area.x + area.width / 2, area.y + area.height / 2);  // 영역의 중심 좌표 계산
            Vector3 size = new Vector3(area.width, area.height);
            Gizmos.DrawCube(center, size); 
        }
    }

    private void StartFlappyGame()
    {

        if (gameStarted) return;  // 중복 실행 방지
        if (miniGameAreas.Count> 0)
        {
            //Debug.Log("미니게임 영역이 존재함");
            Rect rect = miniGameAreas[0];  // 첫 번째 미니게임 영역을 사용
            if (rect.Contains((Vector2)playerController.transform.position))
            {
                gameStarted = true;
                Debug.Log("플레이어가 미니게임 영역에 있음");
                SceneManager.LoadScene("FlappyPlane");  // 미니게임 씬 로드
            }
            else
            {
               // Debug.Log("플레이어가 미니게임 영역에 없음");
            }
            
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartFlappyGame();
    }

}
