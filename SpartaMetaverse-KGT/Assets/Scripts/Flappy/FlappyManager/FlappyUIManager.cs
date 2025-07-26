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
    public Button startButton;
    public Button cancleButton;
    public Button resultCancleButton;
    public Button restartButton;
    public Image image;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameOver()
    {
        result.gameObject.SetActive(true);
        
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
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
