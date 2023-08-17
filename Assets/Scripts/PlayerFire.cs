using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����: ���콺 ������ ��ư�� ���� Ư�� �������� ��ź ��ô
//�ʿ�Ӽ�: ��źGO, ����, �߻� ��ġ, ����
//����1. ���콺 ������ ��ư�� ������.
//����2. ��ź ���ӿ�����Ʈ�� �����ϰ� firePosition�� ��ġ��Ų��.
//����3. ��ź ������Ʈ�� rigidBody�� �����ͼ� ī�޶� ���� �������� ���� ���Ѵ�.

public class PlayerFire : MonoBehaviour
{
    //�ʿ�Ӽ�: ��źGO, ����, �߻� ��ġ, ����
    public GameObject bomb;
    public GameObject firePosition;
    public float power;

    // Update is called once per frame
    void Update()
    {
        //����1. ���콺 ������ ��ư�� ������.
        if (Input.GetMouseButtonDown(1)) // ����0 ������1 ��2
        {
            //����2. ��ź ���ӿ�����Ʈ�� �����ϰ� firePosition�� ��ġ��Ų��.
            GameObject bombGO = Instantiate(bomb);
            bombGO.transform.position = firePosition.transform.position;

            //����3. ��ź ������Ʈ�� rigidBody�� �����ͼ� ���� ���Ѵ�.
            Rigidbody rigidbody = bombGO.GetComponent<Rigidbody>();
            rigidbody.AddForce(Camera.main.transform.forward * power, ForceMode.Impulse);
        }


    }
}
