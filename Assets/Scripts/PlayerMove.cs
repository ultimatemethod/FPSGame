﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목적: wasd 이동
//필요속성: 이동속도
//순서1. 사용자 입력
//순서2. 이동 방향 설정
//순서3. 이동속도에 따라 이동

//목적2. space jump
//필요속성: character controller, gravirt variable, 수직 속력 변수, jump power
//2-1. 캐릭터 수직 속도에 중력 적용
//2-2. 캐릭터 컨트롤러로 나를 이동
//2-3. space 누르면 수직속도에 점프파워 적용

//목적3: 플레이어가 피격을 당하면 hp를 damage만큼 깎는다.
//필요속성: hp

public class PlayerMove : MonoBehaviour
{
    //필요속성: 이동속도
    public float speed = 10f;

    //필요속송: character controller, gravity variable, 수직 속력 변수
    CharacterController characterController;
    float gravity = -20f;
    float yVelocity = 0;
    public float jumpPower = 10;
    public bool isJumping = false;

    //필요속성: hp
    public int hp = 10;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //순서1. 사용자 입력
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //만약 점프 중이었다면 점프 전 상태로 초기화
        if (isJumping && characterController.collisionFlags == CollisionFlags.Below)
        {
            isJumping = false;
            yVelocity = 0;
        }
        //바닥에 닿아있을 때 수직 속도 초기화
        else if (characterController.collisionFlags == CollisionFlags.Below)
        {
            yVelocity = 0; // 계속 쌓이는 거 초기화
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            yVelocity = jumpPower;
            isJumping = true;
        }

        //순서2. 이동 방향 설정
        Vector3 dir = new Vector3(h, 0, v);
        dir = Camera.main.transform.TransformDirection(dir);

        //2-1. 캐릭터 수직 속도에 중력 적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;



        //순서3. 이동속도에 따라 이동
        //transform.position += dir * speed * Time.deltaTime;

        //2-2. character controller로 나를 이동
        characterController.Move(dir * speed * Time.deltaTime);
    }

    //목적3: 플레이어가 피격을 당하면 hp를 damage만큼 깎는다.
    public void DamageAction(int damage)
    {
        hp -= damage;

    }

}
