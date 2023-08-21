using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����: ���콺 ������ ��ư�� ���� Ư�� �������� ��ź ��ô
//�ʿ�Ӽ�: ��źGO, ����, �߻� ��ġ, ����
//����1. ���콺 ������ ��ư�� ������.
//����2. ��ź ���ӿ�����Ʈ�� �����ϰ� firePosition�� ��ġ��Ų��.
//����3. ��ź ������Ʈ�� rigidBody�� �����ͼ� ī�޶� ���� �������� ���� ���Ѵ�.

//����2: ���콺 ���� ��ư�� ������ �ü� �������� ���� �߻��ϰ� �ʹ�.
//2-1. ���콺 ���� ��ư�� ������.
//2-2. ���̸� �����ϰ� �߻� ��ġ�� ������ �����Ѵ�.
//2-3. ���̰� �ε��� ����� ������ ������ �� �ִ� ������ �����.
//2-4. ���̸� �߻��ϰ�, �ε��� ��ü�� ������ �� ��ġ�� �ǰ� ȿ���� �����.

//����3: ���̰� �ε��� ����� Enemy��� Enemy���� �������� �ְڴ�.


public class PlayerFire : MonoBehaviour
{
    //�ʿ�Ӽ�: ��źGO, ����, �߻� ��ġ, ����
    public GameObject bomb;
    public GameObject firePosition;
    public float power;
    
    private PlayerFire playerFire;
    private Transform myTransform;

    //�ʿ�Ӽ�: �ǰ�ȿ��GO, ����Ʈ�� ��ƼŬ �ý���
    public GameObject hitEffect;
    ParticleSystem particleSystem;

    public int weaponPower = 2;

    private void Awake()
    {
        playerFire = GameObject.Find("Player").GetComponent<PlayerFire>();
    }

    private void Start()
    {
        particleSystem = hitEffect.GetComponent<ParticleSystem>();

        //int x = 3;
        //int y = 4;
        //Swap(ref x, ref y);
        //print(string.Format("x:"));
    }
    
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

        //2-1. ���콺 ���� ��ư�� ������.
        if (Input.GetMouseButtonDown(0))
        {
            //2-2. ���̸� �����ϰ� �߻� ��ġ�� ������ �����Ѵ�.
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            //2-3. ���̰� �ε��� ����� ������ ������ �� �ִ� ������ �����.
            RaycastHit hitInfo = new RaycastHit();

            //2-4. ���̸� �߻��ϰ�, 
            if (Physics.Raycast(ray, out hitInfo)) //ref & out
            {
                //print(hitInfo.distance);
                //�ε��� ��ü�� ������ �� ��ġ�� �ǰ� ȿ���� �����.
                hitEffect.transform.position = hitInfo.point;
                hitEffect.transform.forward = hitInfo.normal;

                //�ǰ� ����Ʈ ���
                particleSystem.Play();

                //����3: ���̰� �ε��� ����� Enemy��� Enemy���� �������� �ְڴ�.
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    EnemyFSM enemyFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    enemyFSM.DamageAction(weaponPower);

                }

            }
            

        }

        
    }

    //public void Swap(ref int a, ref int b)
    //{
    //    int temp = a;
    //    a = b;
    //    b = temp;
    //}
}
