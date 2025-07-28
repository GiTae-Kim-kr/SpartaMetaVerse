using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElfUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI dialogueText;  // 엘프 대사 텍스트

    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    private int dialogueStep = 0;  // 대화 단계
    public int DialogueStep { get { return dialogueStep; } set { dialogueStep = value; } }

    private List<string> dialogueYesScripts = new List<string>
    {
        // 처음 대화
        "안녕 모험가! 나는 라우리엘. 종족은 보다시피 엘프야! \n나는 숲과 자연을 사랑하는 엘프지. 마법과 활을 다루는데 능숙하지만, 사실 제일 관심있는건 꾸미는 것! \n 나는 꾸미는 걸 제일 좋아해! 혹시 너만 괜찮다면 널 꾸며줘도 괜찮을까?",
        "좋아! 그럼 시작해보자구!",
        

    };

    private List<string> dialogueNoScripts = new List<string>
    {
         // No 선택 시
        "음.. 그래? 아쉽네 \n하지만 괜찮아! 혹시 뒤늦게라도 꾸미고 싶다면 언제든지 찾아오라구!",
    };

    private void Awake()
    {


        if (dialogueText == null) return;

        
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateScripts(dialogueStep, true, true);

        yesButton.onClick.AddListener(OnYesClicked);
        noButton.onClick.AddListener(OnNoClicked);

        
    }



    public override UIState GetUIState()
    {
        return UIState.Elf;  // 이 UI가 Elf 상태일 때 활성화
    }

        public void UpdateScripts(int dialogueStep, bool setYes, bool setNo)
    {
        

        if (dialogueStep >= 0)
        {
            dialogueText.text = dialogueYesScripts[dialogueStep];
        }
        else if ( dialogueStep < 0)
        {
            dialogueText.text = dialogueNoScripts[Mathf.Abs(dialogueStep) - 1];
        }


        yesButton.gameObject.SetActive(setYes);
        noButton.gameObject.SetActive(setNo);
    }

    void OnYesClicked()
    {
        dialogueStep++;
        if (dialogueStep < dialogueYesScripts.Count)
        {
            if (dialogueYesScripts[dialogueStep] == dialogueYesScripts[1])
            {
                UpdateScripts(dialogueStep, false, true);
            }
            else
                UpdateScripts(dialogueStep, true, true);
        }
        else return;
    }

    void OnNoClicked()
    {

        if (Mathf.Abs(dialogueStep) > dialogueNoScripts.Count) return;

        dialogueStep--;
        UpdateScripts(dialogueStep, true, true);
        


        if (dialogueStep == -1)
        {
            UpdateScripts(dialogueStep, false, false);
            dialogueText.text += "\n\n\n F를 한번 더 누르면 대화를 그만할 수 있어!";
        }

        

    }

}
