using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game3 : MonoBehaviour
{
    public static int Player;
    public static int Points;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 23; i++)
        {
            GameObject.Find(i.ToString()).SetActive(false);
        }
        GameObject.Find("Goal").SetActive(false);

        Player = RollDice.Player;
        Points = TurnManager.Money[Player - 1] / 100 + 2;
        //Player = 1; // for debug
        //Points = 100; // for debug
    }

    // Update is called once per frame
    void Update()
    {
        if (Points <= 0 && !GameObject.Find("Canvas").transform.Find("Goal").gameObject.activeSelf) Failure();
        GameObject.Find("PointsText").GetComponent<Text>().text = "Points: " + Points.ToString();
    }

    public void Failure()
    {
        SceneManager.LoadScene("MainMap");
    }

    public void RandomDelete()
    {
        while (true)
        {
            int random = Random.Range(1, 24);
            if (GameObject.Find("Canvas").transform.Find(random.ToString()).gameObject.activeSelf)
            {
                GameObject.Find("Canvas").transform.Find(random.ToString()).gameObject.SetActive(false);
                break;
            }
        }
    }

    public void ClickGoal()
    {
        TurnManager.Money[Player - 1] += 10000;
        SceneManager.LoadScene("MainMap");
    }

    public void ClickStart()
    {
        // Start button does not cost
        GameObject.Find("Canvas").transform.Find("1").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("7").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("13").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("17").gameObject.SetActive(true);
    }

    public void Click1()
    {
        if (Points >= 2)
        {
            GameObject.Find("Canvas").transform.Find("2").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("15").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("17").gameObject.SetActive(true);
            // First round skills will not delete other skills
            Points -= 2;
        }
    }

    public void Click2()
    {
        if (Points >= 7)
        {
            GameObject.Find("Canvas").transform.Find("1").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("3").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("15").gameObject.SetActive(true);
            RandomDelete();
            Points -= 7;
        }
        
    }

    public void Click3()
    {
        if (Points >= 6)
        {
            GameObject.Find("Canvas").transform.Find("2").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("4").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("15").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("18").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("23").gameObject.SetActive(true);
            RandomDelete();
            Points -= 6;
        }
        
    }

    public void Click4()
    {
        if (Points >= 3)
        {
            GameObject.Find("Canvas").transform.Find("3").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("5").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("16").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("21").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("23").gameObject.SetActive(true);
            RandomDelete();
            Points -= 3;
        }
        
    }

    public void Click5()
    {
        if (Points >= 1)
        {
            GameObject.Find("Canvas").transform.Find("4").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("6").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("16").gameObject.SetActive(true);
            RandomDelete();
            Points -= 1;
        }
    }

    public void Click6()
    {
        if (Points >= 2)
        {
            GameObject.Find("Canvas").transform.Find("5").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("16").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("22").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("Goal").gameObject.SetActive(true);
            RandomDelete();
            Points -= 2;
        }
    }

    public void Click7()
    {
        if (Points >= 3)
        {
            GameObject.Find("Canvas").transform.Find("8").gameObject.SetActive(true);
            // First round skills will not delete other skills
            Points -= 3;
        }
    }

    public void Click8()
    {
        if (Points >= 1)
        {
            GameObject.Find("Canvas").transform.Find("7").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("9").gameObject.SetActive(true);
            RandomDelete();
            Points -= 1;
        }
    }

    public void Click9()
    {
        if (Points >= 1)
        {
            GameObject.Find("Canvas").transform.Find("8").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("10").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("13").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("15").gameObject.SetActive(true);
            RandomDelete();
            Points -= 1;
        }
    }

    public void Click10()
    {
        if (Points >= 5)
        {
            GameObject.Find("Canvas").transform.Find("9").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("11").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("14").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("16").gameObject.SetActive(true);
            RandomDelete();
            Points -= 5;
        }
    }

    public void Click11()
    {
        if (Points >= 1)
        {
            GameObject.Find("Canvas").transform.Find("10").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("12").gameObject.SetActive(true);
            RandomDelete();
            Points -= 1;
        }
    }

    public void Click12()
    {
        if (Points >= 1)
        {
            GameObject.Find("Canvas").transform.Find("11").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("Goal").gameObject.SetActive(true);
            RandomDelete();
            Points -= 1;
        }
    }

    public void Click13()
    {
        if (Points >= 4)
        {
            GameObject.Find("Canvas").transform.Find("9").gameObject.SetActive(true);
            // First round skills will not delete other skills
            Points -= 4;
        }
    }

    public void Click14()
    {
        if (Points >= 10)
        {
            GameObject.Find("Canvas").transform.Find("10").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("Goal").gameObject.SetActive(true);
            RandomDelete();
            Points -= 10;
        }
    }

    public void Click15()
    {
        if (Points >= 5)
        {
            GameObject.Find("Canvas").transform.Find("1").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("2").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("3").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("9").gameObject.SetActive(true);
            RandomDelete();
            Points -= 5;
        }
    }

    public void Click16()
    {
        if (Points >= 7)
        {
            GameObject.Find("Canvas").transform.Find("4").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("5").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("6").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("10").gameObject.SetActive(true);
            RandomDelete();
            Points -= 7;
        }
    }

    public void Click17()
    {
        if (Points >= 1)
        {
            GameObject.Find("Canvas").transform.Find("1").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("18").gameObject.SetActive(true);
            // First round skills will not delete other skills
            Points -= 1;
        }
    }

    public void Click18()
    {
        if (Points >= 4)
        {
            GameObject.Find("Canvas").transform.Find("3").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("17").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("19").gameObject.SetActive(true);
            RandomDelete();
            Points -= 4;
        }
    }

    public void Click19()
    {
        if (Points >= 4)
        {
            GameObject.Find("Canvas").transform.Find("18").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("20").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("23").gameObject.SetActive(true);
            RandomDelete();
            Points -= 4;
        }
    }

    public void Click20()
    {
        if (Points >= 1)
        {
            GameObject.Find("Canvas").transform.Find("19").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("21").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("23").gameObject.SetActive(true);
            RandomDelete();
            Points -= 1;
        }
    }

    public void Click21()
    {
        if (Points >= 10)
        {
            GameObject.Find("Canvas").transform.Find("4").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("20").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("22").gameObject.SetActive(true);
            RandomDelete();
            Points -= 10;
        }
    }

    public void Click22()
    {
        if (Points >= 9)
        {
            GameObject.Find("Canvas").transform.Find("6").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("21").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("Goal").gameObject.SetActive(true);
            RandomDelete();
            Points -= 9;
        }
    }

    public void Click23()
    {
        if (Points >= 7)
        {
            GameObject.Find("Canvas").transform.Find("3").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("4").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("19").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("20").gameObject.SetActive(true);
            RandomDelete();
            Points -= 7;
        }
    }
}
