using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MadArcade : MonoBehaviour
{
    public static int heading;
    public static bool moveleftpossible, moverightpossible, moveuppossible, movedownpossible;

    static int minXcoord = 0, minYcoord = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(1360.0f, 140.0f, 0.0f);
        heading = 0;

        moveleftpossible = true;
        moverightpossible = true;
        moveuppossible = true;
        movedownpossible = true;

        GameObject.Find("Canvas").transform.Find("Bubble").gameObject.SetActive(false);

        for (int i = 0; i < GameObject.Find("Destroyables").transform.childCount; i++)
        {
            GameObject.Find("Destroyables").transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Destroyables").transform.childCount <= 0)
        {
            Finish();
        }
        
        // 물풍선
        if (Input.GetKey(KeyCode.Space))
        {
            float minX = 2000.0f, minY = 2000.0f;

            for (int i = 1; i <= 9; i++)
            {
                int checkX = i * 100 + 460;
                int checkY = i * 100 + 40;
                float distX = Math.Abs(checkX - transform.position.x);
                float distY = Math.Abs(checkY - transform.position.y);

                if (distX < minX)
                {
                    minX = distX;
                    minXcoord = i;
                }
                if (distY < minY)
                {
                    minY = distY;
                    minYcoord = i;
                }
            }

            if ((int)Math.Abs(minXcoord * 100 + 460 - transform.position.x) < 30)
            {
                if ((int)Math.Abs(minYcoord * 100 + 40 - transform.position.y) < 30)
                {
                    StartCoroutine(DestroyControl());
                }
            }
        }

        // 여러 방향키를 동시에 눌러도 먼저 누른 하나만 동작하게 함
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
            {
                heading = 1;
                goto movePlayer;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
            {
                heading = 2;
                goto movePlayer;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.DownArrow))
            {
                heading = 3;
                goto movePlayer;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow))
            {
                heading = 4;
                goto movePlayer;
            }
        }
        else heading = 0;

        movePlayer:
        if (heading == 1) // Left
        {
            if (movePossible(1)) transform.position += new Vector3(-2.5f, 0.0f, 0.0f);
        }
        else if (heading == 2) // Right
        {
            if (movePossible(2)) transform.position += new Vector3(2.5f, 0.0f, 0.0f);
        }
        else if (heading == 3) // Up
        {
            if (movePossible(3)) transform.position += new Vector3(0.0f, 2.5f, 0.0f);
        }
        else if (heading == 4) // Down
        {
            if (movePossible(4)) transform.position += new Vector3(0.0f, -2.5f, 0.0f);
        }
    }

    void Finish()
    {
        TurnManager.Money[RollDice.Player - 1] += 5000;
        SceneManager.LoadScene("MainMap");
    }

    bool movePossible(int head)
    {
        float posx = transform.position.x;
        float posy = transform.position.y;

        // 경계 조건
        if (posx <= 560.0f && head == 1) return false;
        if (posx >= 1360.0f && head == 2) return false;
        if (posy >= 940.0f && head == 3) return false;
        if (posy <= 140.0f && head == 4) return false;

        // 블록 조건
        if (!moveleftpossible && head == 1) return false;
        if (!moverightpossible && head == 2) return false;
        if (!moveuppossible && head == 3) return false;
        if (!movedownpossible && head == 4) return false;

        return true;
    }

    static IEnumerator DestroyControl()
    {
        GameObject.Find("Canvas").transform.Find("Bubble").gameObject.transform.position = new Vector3(minXcoord * 100 + 460, minYcoord * 100 + 40, 0);
        GameObject.Find("Canvas").transform.Find("Bubble").gameObject.SetActive(true);

        yield return new WaitForSeconds(3);
        GameObject.Find("Canvas").transform.Find("Bubble").gameObject.SetActive(false);

        if (minXcoord > 1)
        {
            string left = (10 - minYcoord).ToString() + (minXcoord - 1).ToString();
            if (GameObject.Find(left) && GameObject.Find(left).tag == "Destroyable")
            {
                GameObject.Find("Destroyables").transform.Find(left).gameObject.SetActive(false); // Left
            }
        }
        if (minXcoord < 9)
        {
            string right = (10 - minYcoord).ToString() + (minXcoord + 1).ToString();
            if (GameObject.Find(right) && GameObject.Find(right).tag == "Destroyable")
            {
                GameObject.Find("Destroyables").transform.Find(right).gameObject.SetActive(false); // Right
            }
        }
        if ((10 - minYcoord) < 9)
        {
            string up = ((10 - minYcoord) - 1).ToString() + minXcoord.ToString();
            if (GameObject.Find(up) && GameObject.Find(up).tag == "Destroyable")
            {
                GameObject.Find("Destroyables").transform.Find(up).gameObject.SetActive(false); // Up
            }
        }
        if ((10 - minYcoord) > 1)
        {
            string down = ((10 - minYcoord) + 1).ToString() + minXcoord.ToString();
            if (GameObject.Find(down) && GameObject.Find(down).tag == "Destroyable")
            {
                GameObject.Find("Destroyables").transform.Find(down).gameObject.SetActive(false); // Down
            }
        }
    }
}
