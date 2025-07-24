using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player { get; private set; }
    protected Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();    // 이거 불러와줘야 velocity의 값이 전달됨
        player.Init(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
