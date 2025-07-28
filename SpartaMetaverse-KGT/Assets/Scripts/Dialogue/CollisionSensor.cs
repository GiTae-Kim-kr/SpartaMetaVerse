using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSensor : MonoBehaviour
{
    
    [SerializeField] private LayerMask levelCollisionLayer;    // 레이어 설정

    [Header("플레이어 탐지 반경")] 
    [Range(0f, 20f)][SerializeField] private float radius;


    
    public float Radius 
    { 
        get => radius;
        set => radius = Mathf.Clamp(value, 1f, 20f);
    }

    protected int colliderObject;
    public int ColliderObject { get { return colliderObject; } }

    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected virtual void FixedUpdate()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        
    }

}
