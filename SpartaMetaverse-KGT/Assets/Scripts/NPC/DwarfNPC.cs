using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwrafNPC : MonoBehaviour, INPC
{
    protected UIManager uiManager;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();  // UIManager를 찾아서 할당
        if (uiManager == null)
        {
            Debug.LogError("UIManager 찾을 수 없음!");
        }
    }

    public void Talk()
    {
        Debug.Log("드워프와 대화");
        // ShowEnhanceOptions();   

        uiManager?.ToggleUI(UIState.Dwarf);

    }

    private void ShowEnhanceOptions()  // 대화창 띄우고 장비강화 시스템 들어갈 수는 메서드. UI에서 나중에 제작
    {


    }

}
