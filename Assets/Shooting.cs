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

                //射撃されてから3秒後に銃弾のオブジェクトを破壊する.

                Destroy(bullet, 3.0f);
            }

        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            shotCount = 1;
        }

    }

    private void OnCollisionEnter(Collision collision) //ぶつかったら消える命令文開始
    {
        if (collision.gameObject.CompareTag("target"))//さっきつけたTagutukeruというタグがあるオブジェクト限定で～という条件の下
        {
            Destroy(gameObject);
            score = score + 1;
            Debug.Log("Score:" + score);
            textComponent.text = "Score : " + score;
        }
    }
}