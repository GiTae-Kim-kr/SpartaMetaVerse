using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;  // 따라갈 대상
    float offsetX;            // 거리 유지

    // Start is called before the first frame update
    void Start()
    {
        if (target == null) return;

        offsetX = transform.position.x - target.position.x;    // 카메라와 대상 사이의 x축 오프셋(거리) 계산
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        transform.position = pos;
    }
}
