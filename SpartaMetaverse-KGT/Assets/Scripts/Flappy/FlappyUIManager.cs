using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlappyUIManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;


    void Start()
    {
        if (gameOverText != null)
        {
            Debug.LogError("게임오버 텍스트 없음!");
        }

        if (scoreText != null)
        {
            Debug.LogError("점수 텍스트 없음!");
        }

        gameOverText.gameObject.SetActive(false);  // 처음에는 비활성화. 그냥 수동으로 미리 꺼놓으면 인식을 못할 수도 있어서 코드로 꺼주는게 좋음.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameOver()
    {
        gameOverText.gameObject.SetActive(true);
        
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

}
