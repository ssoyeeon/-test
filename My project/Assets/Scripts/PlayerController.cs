using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;            // �÷��̾ �̵���Ű�� ���� RigidBody
    public StatData player;
    public float attackCooldown;
    public float currentCooldown;
    public GameObject bullet;

    void Start()
    {
        rb = GetComponent<Rigidbody>();         // rb�� ������Ʈ �ȿ� �ִ� rigidBody�� �־���
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

    public void PlayerMove01()      // �÷��̾��� ��ġ�� �ٲپ� �̵���Ű�� ����� �Լ�
    {
        Vector3 moveInput = new Vector3(0,0,0);

        moveInput.x = Input.GetAxisRaw("Horizontal");           // �¿� �̵� �Է��� �޾ƿ�
        moveInput.z = Input.GetAxisRaw("Vertical");             // ���� �̵� �Է��� �޾ƿ�

        moveInput.Normalize();                                  // �밢�� ���� ����
        transform.position += moveInput * player.moveSpeed * Time.deltaTime;        // �÷��̾��� ������Ʈ�� �̵�
    }

    public void PlayerMove02() 
    {
        Vector3 moveInput = new Vector3(0, 0, 0);

        moveInput.x = Input.GetAxisRaw("Horizontal");           // �¿� �̵� �Է��� �޾ƿ�
        moveInput.z = Input.GetAxisRaw("Vertical");             // ���� �̵� �Է��� �޾ƿ�

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
