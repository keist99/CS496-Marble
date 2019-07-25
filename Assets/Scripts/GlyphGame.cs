using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlyphGame : MonoBehaviour
{
    static bool available;
    static int count, maxcount;
    static int[] push;
    static bool[] answer;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonClean();
        available = true;
        count = 0;
        maxcount = Random.Range(1, 6);
        push = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        answer = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false };
        GameObject.Find("Submit").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (available && count < maxcount)
        {
            available = false;
            count++;
            buttonClean();
            sequence(Random.Range(1, 9));
            StartCoroutine(CycleControl());
        }
        if (available && count >= maxcount)
        {
            buttonClean();
            GameObject.Find("Canvas").transform.Find("Name").gameObject.SetActive(false);
            GameObject.Find("IncomingSequence").GetComponent<Text>().text = "Click Colored Squares";
            GameObject.Find("Canvas").transform.Find("Submit").gameObject.SetActive(true);
        }
    }

    void buttonClean()
    {
        for (int i = 1; i <= 11; i++) GameObject.Find("Button" + i.ToString()).GetComponent<Image>().color = Color.white;
    }

    public void buttonSubmit()
    {
        bool same = true;
        for (int i = 1; i <= 11; i++)
        {
            if (push[i] == 1 && !answer[i])
            {
                same = false;
                break;
            }
            else if (push[i] == 0 && answer[i])
            {
                same = false;
                break;
            }
        }
        if (same) win();
        else failure();
    }

    void win()
    {
        TurnManager.Money[RollDice.Player - 1] += 3000;
        SceneManager.LoadScene("MainMap");
    }

    void failure()
    {
        TurnManager.Money[RollDice.Player - 1] -= 3000;
        SceneManager.LoadScene("MainMap");
    }

    void Coloring(int k)
    {
        GameObject.Find("Button" + k.ToString()).GetComponent<Image>().color = Color.magenta;
        push[k] = 1;
    }

    void NameChange(string k)
    {
        GameObject.Find("Name").GetComponent<Text>().text = k + "..";
    }

    void sequence(int k)
    {
        switch (k)
        {
            // https://ingress.fandom.com/wiki/Glyphs

            case 1:
                {
                    Coloring(2);
                    Coloring(3);
                    Coloring(6);
                    Coloring(7);
                    Coloring(10);
                    Coloring(11);
                    NameChange("Abandon");
                    break;
                }
            case 2:
                {
                    Coloring(5);
                    Coloring(8);
                    Coloring(10);
                    Coloring(11);
                    NameChange("Adapt");
                    break;
                }
            case 3:
                {
                    Coloring(1);
                    Coloring(3);
                    Coloring(9);
                    NameChange("Advance");
                    break;
                }
            case 4:
                {
                    Coloring(4);
                    Coloring(6);
                    Coloring(7);
                    Coloring(8);
                    Coloring(11);
                    NameChange("After");
                    break;
                }
            case 5:
                {
                    Coloring(3);
                    Coloring(7);
                    Coloring(8);
                    Coloring(9);
                    Coloring(10);
                    Coloring(11);
                    NameChange("Repeat");
                    break;
                }
            case 6:
                {
                    for (int i = 1; i <= 6; i++) Coloring(i);
                    NameChange("All");
                    break;
                }
            case 7:
                {
                    Coloring(7);
                    Coloring(8);
                    Coloring(9);
                    Coloring(11);
                    NameChange("Answer");
                    break;
                }
            case 8:
                {
                    Coloring(1);
                    Coloring(3);
                    Coloring(4);
                    Coloring(7);
                    Coloring(9);
                    NameChange("Attack");
                    break;
                }
        }
    }

    static IEnumerator CycleControl()
    {
        yield return new WaitForSeconds(2);
        available = true;
    }

    void push1()
    {
        answer[1] = true;
    }

    void push2()
    {
        answer[2] = true;
    }

    void push3()
    {
        answer[3] = true;
    }

    void push4()
    {
        answer[4] = true;
    }

    void push5()
    {
        answer[5] = true;
    }

    void push6()
    {
        answer[6] = true;
    }

    void push7()
    {
        answer[7] = true;
    }

    void push8()
    {
        answer[8] = true;
    }

    void push9()
    {
        answer[9] = true;
    }

    void push10()
    {
        answer[10] = true;
    }

    void push11()
    {
        answer[11] = true;
    }
}
