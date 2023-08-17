using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목적: 
public class PlayerRotate : MonoBehaviour
{
    //필요속성: 마우스 입력 X, Y, 속도 
    public float speed = 200f;

    // Update is called once per frame
    void Update()
    {
        //순서1. 마우스 입력(X, Y) 받는다.
        float mouseX = Input.GetAxis("Mouse X");
        

        //순서2. 마우스 입력에 따라 방향 설정
        Vector3 dir = new Vector3(0, mouseX, 0);

        //순서3. 물체 회전
        //r = r0 + vt
        transform.eulerAngles = transform.eulerAngles + dir * speed * Time.deltaTime;


    }
}
