using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목적: 마우스 입력 받아 카메라 회전
//필요속성: 마우스 입력 X, Y, 속도 
//순서1. 마우스 입력 받는다.
//순서2. 마우스 입력에 따라 방향 설정
//순서3. 물체 회전
public class CamRotate : MonoBehaviour
{
    //필요속성: 마우스 입력 X, Y, 속도 
    public float speed = 10f;
    float mx = 0;
    float my = 0;




    // Update is called once per frame
    void Update()
    {
        //순서1. 마우스 입력(X, Y) 받는다.
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        mx += mouseX * speed * Time.deltaTime;
        my += mouseY * speed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90f);

        //순서2. 마우스 입력에 따라 방향 설정
        Vector3 dir = new Vector3(-my, mx, 0);


        //순서3. 물체 회전
        //r = r0 + vt
        transform.eulerAngles = dir;


    }
}
