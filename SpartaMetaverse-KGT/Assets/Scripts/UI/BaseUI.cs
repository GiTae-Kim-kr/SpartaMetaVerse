using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;

    public virtual void Init(UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    public abstract UIState GetUIState();  // UI 상태를 반환하는 추상 메서드

    public void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIState() == state);  // 반환한 UI 상태와 비교해서 활성화 여부 결정
    }
}
