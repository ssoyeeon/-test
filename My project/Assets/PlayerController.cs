using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;   //플레이어를 이동시키기 위한 Rigidbody
    public int moveSpeed = 5;    // 플레이어의 이동속도
    // Start is called before the first frame update
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();   //rb에 오브젝트 안에 있는 rigidbody를 넣어줌
    }

    void Update()
    {
        //PlayerMove01();
        PlayerMove02();
    }
    public void PlayerMove01()  //플레이어의 위치를 바꾸어 이동시키게 만드는 함수

    {
        Vector3 moveInput = new Vector3(0,0,0);

        moveInput.x = Input.GetAxisRaw("Horizontal");  //좌우 이동 입력을 받아옴
        moveInput.y = Input.GetAxisRaw("Vertical");  //상하 이동 입력을 받아옴

        moveInput.Normalize(); //대각선 가속 방지
        transform.position += moveInput * moveSpeed * Time.deltaTime; //플레이어의 오브젝트를 이용
    }

    public void PlayerMove02()
    {
        Vector3 moveInput = new Vector3(0,0,0);

        moveInput.x = Input.GetAxisRaw("Horizontal");  //좌우 이동 입력을 받아옴
        moveInput.y = Input.GetAxisRaw("Vertical");  //상하 이동 입력을 받아옴

        moveInput.Normalize();

        rb.velocity = moveInput * moveSpeed;
    }
}
