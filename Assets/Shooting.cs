using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    public Text textComponent;

    public GameObject bulletPrefab;
    public float shotSpeed;
    public int shotCount = 1;
    private float shotInterval;

    private int score;

    private void Start()
    {
        score = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {

            shotInterval += 1;

            if (shotInterval % 50 == 0 && shotCount > 0)
            {
                shotCount -= 1;

                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * shotSpeed);

                //�ˌ�����Ă���3�b��ɏe�e�̃I�u�W�F�N�g��j�󂷂�.

                Destroy(bullet, 3.0f);
            }

        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            shotCount = 1;
        }

    }

    private void OnCollisionEnter(Collision collision) //�Ԃ�����������閽�ߕ��J�n
    {
        if (collision.gameObject.CompareTag("target"))//����������Tagutukeru�Ƃ����^�O������I�u�W�F�N�g����Ł`�Ƃ��������̉�
        {
            Destroy(gameObject);
            score = score + 1;
            Debug.Log("Score:" + score);
            textComponent.text = "Score : " + score;
        }
    }
}