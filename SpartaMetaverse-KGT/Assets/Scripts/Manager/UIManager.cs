using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public enum UIState
{
    None,
    Elf,
    Dwarf,
}
public class UIManager : MonoBehaviour
{
    [SerializeField] private List<BaseUI> uiList;  // UI 컴포넌트 리스트로 저장
    private Dictionary<UIState, BaseUI> uiDict;
    private UIState currentState = UIState.None;

    protected void InitState()
    {
        currentState = UIState.None;
        foreach (var ui in uiDict.Values)
            ui.gameObject.SetActive(false); 
    }


    private void Awake()
    {
        uiDict = new Dictionary<UIState, BaseUI>();  // UI 상태와 UI 컴포넌트를 매핑할 딕셔너리 생성
        foreach (var ui in uiList)
            uiDict.Add(ui.GetUIState(), ui);  // 각 UI 상태와 컴포넌트를 딕셔너리에 추가    

        InitState();

    }

    public void ChangeState(UIState state)
    {
        InitState();

        if (state != UIState.None && uiDict.ContainsKey(state))  // 현재 상태가 None이 아니고 딕셔너리에 해당 상태가 존재하면
            uiDict[state].gameObject.SetActive(true);

        currentState = state;
    }

    public void ToggleUI(UIState state)  // 한번 더 누르면 꺼지게 설정
    {
        if (currentState == state)
        {
            ChangeState(UIState.None);  //이미 켜져 있으면 끔
        }
        else
        {
            ChangeState(state); // 켜져 있지 않으면 다시 켬.
        }
    }



}
