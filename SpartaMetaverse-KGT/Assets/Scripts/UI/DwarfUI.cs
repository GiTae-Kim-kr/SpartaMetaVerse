using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfUI : BaseUI
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override UIState GetUIState()
    {
        return UIState.Dwarf;  // 이 UI가 Dwarf 상태일 때 활성화
    }
}
