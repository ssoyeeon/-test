using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;            // 플레이어를 이동시키기 위한 RigidBody
    public StatData player;
    public float attackCooldown;
    public float currentCooldown;
    public GameObject bullet;

    void Start()
    {
        rb = GetComponent<Rigidbody>();         // rb에 오브젝트 안에 있는 rigidBody를 넣어줌
        player = Managers.Data.Setting(true, 5, 5, 1, 1, 5);
    }

    void Update()
    {
        //PlayerMove01();
        PlayerMove02();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    public void PlayerMove01()      // 플레이어의 위치를 바꾸어 이동시키게 만드는 함수
    {
        Vector3 moveInput = new Vector3(0,0,0);

        moveInput.x = Input.GetAxisRaw("Horizontal");           // 좌우 이동 입력을 받아옴
        moveInput.z = Input.GetAxisRaw("Vertical");             // 상하 이동 입력을 받아옴

        moveInput.Normalize();                                  // 대각선 가속 방지
        transform.position += moveInput * player.moveSpeed * Time.deltaTime;        // 플레이어의 오브젝트를 이동
    }

    public void PlayerMove02() 
    {
        Vector3 moveInput = new Vector3(0, 0, 0);

        moveInput.x = Input.GetAxisRaw("Horizontal");           // 좌우 이동 입력을 받아옴
        moveInput.z = Input.GetAxisRaw("Vertical");             // 상하 이동 입력을 받아옴

        moveInput.Normalize();
        
        rb.velocity = moveInput * player.moveSpeed;
    }

    public void FireProjectile()
    {
        GameObject temp = Managers.Pool.Pop(bullet);
        BulletController bc = temp.GetComponent<BulletController>();

        temp.transform.position = this.gameObject.transform.position;
        bc.direction = Vector3.forward;
        bc.damage = player.bulletDamage;
        bc.moveSpeed = player.bulletLevel;

        Managers.Data.Bullets.Add(bc);
    }
}
