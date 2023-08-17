using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목적: 특정 시간 지나면 이펙트 제거
//필요속성: 특정시간, 현재시간
public class EffectDestroy : MonoBehaviour
{
    //필요속성: 특정시간, 현재시간
    public float destroyTime = 1.5f;
    float currentTime;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        //목적: 특정 시간 지나면 이펙트 제거
        if (currentTime > destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
