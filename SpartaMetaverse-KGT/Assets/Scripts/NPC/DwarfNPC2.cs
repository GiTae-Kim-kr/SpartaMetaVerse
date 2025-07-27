using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwrafNPC2 : MonoBehaviour, INPC
{
    protected UIManager uiManager;
    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        if (uiManager == null)
        {
            Debug.LogError("UIManager 찾을 수 없음!");
        }
    }

    public void Talk()
    {
        Debug.Log("드워프와 대화2");
        // ShowEnhanceOptions();   
        uiManager?.ToggleUI(UIState.MiniGame); // UIManager를 통해 미니게임 결과창 활성화

    }

    private void ShowEnhanceOptions()  // 대화창 띄우고 장비강화 시스템 들어갈 수는 메서드. UI에서 나중에 제작
    {


    }

}

