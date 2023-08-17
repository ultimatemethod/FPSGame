using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목적: 폭탄이 물체에 부딪히면 파괴
//필요속성: 폭발 이펙트

public class BombAction : MonoBehaviour
{
    //필요속성: 폭발 이펙트
    public GameObject bombEffect;


    //목적: 폭탄이 물체에 부딪히면 파괴
    private void OnCollisionEnter(Collision collision)
    {
        //이펙트 만든다
        GameObject bombEffGO = Instantiate(bombEffect);

        //이펙트의 위치를 내 위치로
        bombEffGO.transform.position = transform.position;

        Destroy(gameObject);

    }
}
