using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyUIManager : MonoBehaviour
{
    public GameObject result;  // 결과 UI 오브젝트
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreResult;
    public TextMeshProUGUI currentScoreResult;
    public Button startButton;
    public Button cancleButton;
    public Button resultCancleButton;
    public Button restartButton;
    public Image image;

    private int bestScore = 0;
    public int BestScore {  get { return bestScore; } }
    private const string bestScoreKey = "BestScore"; // 최고 점수를 저장할 키
    void Start()
    {
        if (result != null)
        {
            Debug.LogError("게임오버 창 없음!");
        }

        if (scoreText != null)
        {
            Debug.LogError("점수 텍스트 없음!");
        }

        result.gameObject.SetActive(false);  // 처음에는 비활성화. 그냥 수동으로 미리 꺼놓으면 인식을 못할 수도 있어서 코드로 꺼주는게 좋음.

        startButton.onClick.AddListener(OnStartButton);
        cancleButton.onClick.AddListener(OnCancleButton);
        resultCancleButton.onClick.AddListener(OnCancleButton);
        restartButton.onClick.AddListener(OnRestartButton);

        
        bestScore = PlayerPrefs.GetInt(bestScoreKey, 0); // PlayerPrefs에서 최고 점수 가져오기. 없으면 0으로 초기화.
        // PlayerPrefs는 게임의 설정이나 데이터를 저장하는데 사용되는 Unity의 간단한 데이터 저장 시스템.

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameOver()
    {
        
        result.gameObject.SetActive(true);
        
        currentScoreResult.text = scoreText.text;  // 현재 점수 표시
        bestScoreResult.text = bestScore.ToString();
        Debug.Log($"ShowGameOver 호출: currentScore={scoreText.text}, bestScore={bestScore}");
    }

    public void UpdateScore(int score)
    {
        Debug.Log($"UpdateScore 호출: score={score}, bestScore={bestScore}");
        scoreText.text = score.ToString();
        bestScoreResult.text = bestScore.ToString();

        if (bestScore < score)
        {
            bestScore = score;  // 최고 점수 갱신

            PlayerPrefs.SetInt(bestScoreKey, bestScore);  // PlayerPrefs에 최고 점수 저장.
            bestScoreResult.text = bestScore.ToString();

        }

        

    }

    public void UpdateBestScore()
    {

    }




    public void OnStartButton()
    {
        
        if (image != null)
        {
            image.gameObject.SetActive(false);  // 버튼 누르면 이미지 비활성화.
            Time.timeScale = 1f; // 게임 시작시 일시정지 해제
        }
        else Debug.LogError("이미지 없음!");

    }

    public void OnCancleButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnRestartButton()
    {
        MiniGameManager.Instance.RestartGame();
    }

}
