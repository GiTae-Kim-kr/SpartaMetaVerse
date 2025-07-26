using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public PlayerController player { get; private set; }
    protected Rigidbody2D _rigidbody;
    protected MiniGameManager miniGameManager;

    public static GameManager Instance
    {
        get { return gameManager; }
    }
    private int currentScore = 0;  // 현재 점수

    private void Awake()
    {
        gameManager = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();    // 이거 불러와줘야 velocity의 값이 전달됨

        miniGameManager = FindObjectOfType<MiniGameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // 현재 씬을 다시 로드하여 게임 재시작
    }

    public void AddScore(int score)
    {
        currentScore += score;  // 점수 추가
        Debug.Log("Current Score : " + currentScore);
    }

}
