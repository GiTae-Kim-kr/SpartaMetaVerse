using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfNPC : MonoBehaviour, INPC
{
    protected UIManager uiManager;
    [SerializeField] private ElfUI elfUI;

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
        Debug.Log("엘프와 대화");
        // StackMiniGame();   
        elfUI.DialogueStep = 0;
        elfUI.UpdateScripts(0, true, true);
        uiManager?.ToggleUI(UIState.Elf); // UIManager를 통해 엘프 대화창 활성화

    }

    private void StackMiniGame()  // 대화창 띄우고 장비강화 시스템 들어갈 수는 메서드. UI에서 나중에 제작
    {


    }

}
