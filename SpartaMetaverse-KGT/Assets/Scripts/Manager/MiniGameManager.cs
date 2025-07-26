using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    static MiniGameManager instance;

    protected FlappyUIManager flappyUIManager;
    public int currentScore = 0;

    public static MiniGameManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;  // 싱글톤인스턴스 생성. instance에 현재 스크립트의 인스턴스를 할당.
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 0f; // 게임 시작시 일시정지 상태.
    }

    // Start is called before the first frame update
    void Start()
    {
        flappyUIManager = FindObjectOfType<FlappyUIManager>();

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        flappyUIManager.ShowGameOver();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // 현재 씬을 다시 로드하여 게임 재시작
    }

    public void AddScore(int score)
    {
        currentScore += score;  // 점수 추가
        flappyUIManager.UpdateScore(currentScore);


    }
}
