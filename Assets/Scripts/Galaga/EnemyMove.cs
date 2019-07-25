﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    public int MoveSpeed;

    public static int deadEnemy;

    public static Enemy_Data enemyData;

    public float stoppingDistance;
    public float retreatDistance;

    public Transform player;

    void Start()
    {
        player = GameObject.Find("Spaceship").transform;
        enemyData = new Enemy_Data(25);
        deadEnemy = 0;
    }

    void Update()
    {
        // 매 프레임마다 미사일이 MoveSpeed 만큼 up방향(Y축 +방향)으로 날라갑니다.
        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            if (player.position.x > transform.position.x)
            {
                transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, MoveSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
        }

        // 만약에 미사일의 위치가 DestroyYPos를 넘어서면
        if (transform.position.x <= -50)
        {
            // 미사일을 제거
            Destroy(gameObject);
        }

        if (deadEnemy >= 20)
        {
            GalagaOut.Finish();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딛히는 collision을 가진 객체의 태그가 "Click"이나 "Player"일 경우
        if (collision.CompareTag("Click"))
        {
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
}
