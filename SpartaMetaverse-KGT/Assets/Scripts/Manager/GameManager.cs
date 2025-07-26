using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public PlayerController player { get; private set; }
    protected Rigidbody2D _rigidbody;
    protected MiniGameController miniGameManager;
    protected FlappyUIManager flappyUIManager;
    protected MiniGameResultUI miniGameResultUI;
    public static GameManager Instance
    {
        get { return gameManager; }
    }
    private int currentScore = 0;  // 현재 점수

    private void Awake()
    {
        gameManager = this;
        flappyUIManager = FindObjectOfType<FlappyUIManager>();


    }


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();    // 이거 불러와줘야 velocity의 값이 전달됨
     
        miniGameManager = FindObjectOfType<MiniGameController>();
        player.Init(this);  // 플레이어 컨트롤러 초기화
        
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
