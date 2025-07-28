using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameResultUI : BaseUI
{
    [SerializeField] private Image image;  // 결과 이미지
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        if (uiManager == null)
        {
            Debug.LogError("UIManager를 찾을 수 없음!");
        }
    }
        
    // Start is called before the first frame update
    void Start()   // UI 활성화 상태 아니면 start가 호출되지 않음.
    {
        ShowResult();
        ShowResultScore();
        exitButton.onClick.AddListener(OnExitButton);
    }


    public override UIState GetUIState()
    {
        return UIState.MiniGame;  // 이 UI가 Elf 상태일 때 활성화
    }

    protected void OnExitButton()
    {
        uiManager.ChangeState(UIState.None);
    }

    public void ShowResultScore()
    {
        int currentScore = PlayerPrefs.GetInt("CurrentScore", 0 );
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        currentScoreText.text = currentScore.ToString();  // 현재 점수 표시
        bestScoreText.text = bestScore.ToString();

        Debug.Log($"ShowResult 호출: currentScore={currentScore}, bestScore={bestScore}");
    }

    public void ShowResult()
    {
        if (PlayerPrefs.GetInt("ShowResultUI", 0) == 1)
        {
            uiManager.ChangeState(UIState.MiniGame);
            Debug.Log("1인거 읽어 왔음!");
            PlayerPrefs.SetInt("ShowResultUI", 0);
        }
    }

}
