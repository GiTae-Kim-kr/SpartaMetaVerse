using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElfUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI elfVerse;  // 엘프 대사 텍스트
    [SerializeField] private Button exitButton;


    private void Awake()
    {


        if (elfVerse == null) return;

        SetElfVerse();

       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void SetElfVerse()
    {
        elfVerse.text = "안녕 모험가! 나는 라우리엘. 종족은 보다시피 엘프야! \n" +
            "나는 숲과 자연을 사랑하는 엘프지. 마법과 활을 다루는데 능숙해. 참고하라구! \n";
    }

    protected void OnExitButton()
    {
        
    }

    public override UIState GetUIState()
    {
        return UIState.Elf;  // 이 UI가 Elf 상태일 때 활성화
    }

}
