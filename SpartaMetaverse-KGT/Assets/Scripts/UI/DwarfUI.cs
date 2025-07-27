using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DwarfUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI dwarfText;
    [SerializeField] private TextMeshProUGUI dwarfTextYes;
    [SerializeField] private TextMeshProUGUI dwarfTextNo;

    [SerializeField] private List<string> dialogueTexts;

    private void Awake()
    {
        if (dwarfText == null) return;

        DwarfTextSelect();
    }




    public override UIState GetUIState()
    {
        return UIState.Dwarf;  // 이 UI가 Dwarf 상태일 때 활성화
    }

    private void DwarfTextSelect()
    {
        dwarfTextList = new List<string>
        {
            dwarfText.text = "안녕, 모험가! 나는 드워프야. \n" +
            "나는 대장장이로서 무기와 방어구를 만드는데 능숙해. \n" +
            "내가 만든 장비는 강력하고 내구성이 뛰어나지.\n" +
            "지금은 망치가 없어서 도움이 되지 않지만, 언젠가는 다시 망치를 들고 대장장이 일을 할 수 있을 거야.\n" +
            "............\n" +
            ".............\n" +
            "혹시... 망치를 가지고 있니?\n";
        };


        
    }

    private void SelectYes()
    {
        dwarfTextYes.text = "네!\n";
    }

    private void SeleftNo()
    {
        dwarfTextNo.text = "아니요..";
    }

}
