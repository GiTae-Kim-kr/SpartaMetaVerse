using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DwarfUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    private int dialogueStep;  // 대화 단계
    public int DialogueStep { get { return dialogueStep; } set { dialogueStep = value; } }



    private List<string> dialogueYesScripts = new List<string>
    {
        // 처음 대화
        "안녕하신가, 모험가! 나는 드워프라네.나는 대장장이로서 무기와 방어구를 만드는데 능숙하지.\n또 더 강하게 만드는 것도 가능하다네.\n지금은 망치가 없어서 도움이 되지 않지만, 언젠가는 다시 망치를 들고 대장장이 일을 할 수 있을 걸세!\n............\n..............\n혹시... 자네, 망치를 가지고 있나?",
        // Yes 선택 시
        "오! 자네!! 망치를 가지고 있군!\n 혹시 그 망치를 나에게 주겠나?\n 망치를 내게 준다면 자네가 가진 무기를 공짜로 강화해 주겠네!!\n 물론, 지금은 3단계 까지만 가능하다네.",
       
    };

    private List<string> dialogueNoScripts = new List<string>
    {
         // No 선택 시
        "이런... 아쉽군.\n 망치가 없으면 내가 할 수 있는 일이 없네.\n 하지만 언젠가는다시 망치를 들고 대장장이 일을 할 수 있을 걸세!\n 그때까지는 자네가 가진 무기를 잘 관리하길 바라네.",
    };


    private void Awake()
    {
        if (dialogueText == null) return;


    }

    private void Start()
    {
        UpdateScripts(dialogueStep, true, true);  // 초기 대화 스크립트


        yesButton.onClick.AddListener(OnYesClicked);
        noButton.onClick.AddListener(OnNoClicked);

    }




    public override UIState GetUIState()
    {
        return UIState.Dwarf;  // 이 UI가 Dwarf 상태일 때 활성화
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
            dialogueText.text += "\n F를 한번 더 누르면 대화를 그만할 수 있네";
        }

        

    }
}

