using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSprite;  // 플레이어 스프라이트랜더러 가져옴


    public void HorseRide()
    {
        Vector2 player = playerSprite.transform.position;
        player.x = transform.position.x;
        player.y = transform.position.y + 2f;

        playerSprite.transform.position = player;
    }


}
