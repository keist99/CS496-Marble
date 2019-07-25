using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapAction : MonoBehaviour
{
    static MapAction mSelf;

    void Start()
    {
        mSelf = this;
    }

    public static void PlaceAction(int Player, int Place)
    {
        switch (Place)
        {
            case 1:
                {
                    // Nothing to do
                    break;
                }

            // 미니게임

            case 3:
                {
                    // Galaga
                    Galaga.Player = Player;
                    SceneManager.LoadScene("Galaga");
                    break;
                }
            case 26:
                {
                    // Lottery
                    RandomGame.Player = Player;
                    SceneManager.LoadScene("RandomGame");
                    break;
                }
            case 34:
                {
                    // Enhancement
                    SceneManager.LoadScene("Game3");
                    break;
                }
            case 27:
                {
                    // Maze
                     SceneManager.LoadScene("Game4");
                    
                    break;
                }
            case 12:
                {
                    // Glypher
                    SceneManager.LoadScene("Glyph");
                    break;
                }
            case 23:
                {
                    // Course Registration
                    SceneManager.LoadScene("Game6");
                    break;
                }
            case 16:
                {
                    // Mad Arcade
                    SceneManager.LoadScene("MadArcade");
                    break;
                }

            // 이동

            case 8:
                {
                    // Back 1
                    CharacterPosition.MovePlayer(Player, -1);
                    PlaceAction(Player, Place - 1);
                    MapResult("한 칸 뒤로!");
                    GameObject.Find("Canvas").transform.Find("Ladder1").gameObject.SetActive(true);
                    mSelf.StartCoroutine(MoveCycleControl(1));
                    break;
                }
            case 19:
                {
                    // Back 1
                    CharacterPosition.MovePlayer(Player, -1);
                    PlaceAction(Player, Place - 1);
                    MapResult("한 칸 뒤로!");
                    GameObject.Find("Canvas").transform.Find("Ladder2").gameObject.SetActive(true);
                    mSelf.StartCoroutine(MoveCycleControl(2));
                    break;
                }
            case 31:
                {
                    // Back 2
                    CharacterPosition.MovePlayer(Player, -2);
                    PlaceAction(Player, Place - 2);
                    MapResult("두 칸 뒤로!");
                    GameObject.Find("Canvas").transform.Find("Ladder3").gameObject.SetActive(true);
                    mSelf.StartCoroutine(MoveCycleControl(3));
                    break;
                }
            case 33:
                {
                    // Front 2
                    CharacterPosition.MovePlayer(Player, 2);
                    PlaceAction(Player, Place + 2);
                    MapResult("두 칸 앞으로!");
                    GameObject.Find("Canvas").transform.Find("Ladder4").gameObject.SetActive(true);
                    mSelf.StartCoroutine(MoveCycleControl(4));
                    break;
                }
            case 29:
                {
                    // Golden Key
                    GoldenKey(Player, Place, Random.Range(1, 6));
                    break;
                }
            case 4:
                {
                    // World Travel: Move To Random Place
                    int move = Random.Range(1, 35);
                    CharacterPosition.MovePlayer(Player, move);
                    PlaceAction(Player, Place + move);
                    MapResult("세계 여행: 임의의 지점으로!");
                    break;
                }
            case 13:
                {
                    // Go to Start
                    CharacterPosition.MovePlayer(Player, -12);
                    PlaceAction(Player, Place - 12);
                    MapResult("출발 지점으로!");
                    break;
                }

            // 턴

            case 17:
                {
                    // Rest a turn
                    RollDice.RestTurn[Player - 1]++;
                    MapResult("한 턴 보내기!");
                    break;
                }
            case 18:
            case 25:
                {
                    // Island: Rest three turns
                    RollDice.RestTurn[Player - 1] += 3;
                    MapResult("무인도!");
                    break;
                }
            case 24:
                {
                    // Start a new turn
                    Player = (Player == 1) ? 2 : 1;
                    MapResult("새로운 턴 시작!");
                    break;
                }
            case 15:
                {
                    // Professor: 1-2학년 과목 중 하나를 살 수 있음
                    Inventory.addRandom(Player);
                    break;
                }

            // 과목
            // 순서: 프밍기, 논설, 시프, 자구, AI, 네트워크, 그래픽스, OS, 확률, 컴구

            case 2:
            case 5:
                {
                    // Programming Basics: Code 1
                    Inventory.search(1, Player);
                    break;
                }
            case 6:
                {
                    // Logic Design: Code 2, 선이수과목 프밍기(1)
                    Inventory.searchPre(2, Player, 1);
                    break;
                }
            case 7:
                {
                    // System Programming: Code 3, 선이수과목 프밍기(1)
                    Inventory.searchPre(3, Player, 1);
                    break;
                }
            case 9:
            case 21:
                {
                    // Data Structure: Code 4, 선이수과목 프밍기(1)
                    Inventory.searchPre(4, Player, 1);
                    break;
                }
            case 11:
                {
                    // AI: Code 5, 선이수과목 자구(4)
                    Inventory.searchPre(5, Player, 4);
                    break;
                }
            case 14:
                {
                    // Network: Code 6, 선이수과목 확률과 통계(9)
                    Inventory.searchPre(6, Player, 9);
                    break;
                }
            case 20:
                {
                    // Graphics: Code 7, 선이수과목 자구(4)
                    Inventory.searchPre(7, Player, 4);
                    break;
                }
            case 22:
                {
                    // Operating Systems: Code 8, 선이수과목 시프(3)
                    Inventory.searchPre(8, Player, 3);
                    break;
                }
            case 28:
                {
                    // Probability and Statistics: Code 9, 선이수과목 프밍기(1)
                    Inventory.searchPre(9, Player, 1);
                    break;
                }
            case 32:
                {
                    // Computer Architecture: Code 10, 선이수과목 논설(2)
                    Inventory.searchPre(10, Player, 2); 
                    break;
                }

            // 코인

            case 10:
                {
                    // Black Cat: -400 Coins
                    TurnManager.Money[Player - 1] -= 400;
                    GameObject.Find("Money").GetComponent<Text>().text = "Money: " + TurnManager.Money[Player - 1].ToString();
                    MapResult("검은 고양이의 저주: -400 Coins");
                    break;
                }
            case 30:
                {
                    // Four Leaves Clover: +300 Coins
                    TurnManager.Money[Player - 1] += 300;
                    GameObject.Find("Money").GetComponent<Text>().text = "Money: " + TurnManager.Money[Player - 1].ToString();
                    MapResult("네잎 클로버: +300 Coins");
                    break;
                }

            default:
                {
                    break;
                }
        }
        GameObject.Find("Money").GetComponent<Text>().text = "Money: " + TurnManager.Money[Player - 1].ToString();
    }

    public static void GoldenKey(int Player, int Place, int number)
    {
        // Golden Key
        switch (number)
        {
            case 1:
                {
                    // Lottery: +1200 Coins
                    TurnManager.Money[Player - 1] += 1200;
                    GameObject.Find("Money").GetComponent<Text>().text = "Money: " + TurnManager.Money[Player - 1].ToString();
                    MapResult("복권 당첨: +1200 Coins");
                    break;
                }
            case 2:
                {
                    // Tax: -100 Coins per Course
                    if (Player == 1)
                    {
                        int sum = 0;
                        for (int i = 0; i < 10; i++)
                        {
                            sum += Inventory.inventory1[i];
                        }
                        TurnManager.Money[Player - 1] -= sum * 100;
                    }
                    else
                    {
                        int sum = 0;
                        for (int i = 0; i < 10; i++)
                        {
                            sum += Inventory.inventory2[i];
                        }
                        TurnManager.Money[Player - 1] -= sum * 100;
                    }
                    GameObject.Find("Money").GetComponent<Text>().text = "Money: " + TurnManager.Money[Player - 1].ToString();
                    break;
                }
            case 3:
                {
                    // Highway: Go to Start
                    CharacterPosition.MovePlayer(Player, 6);
                    PlaceAction(Player, Place + 6);
                    MapResult("고속도로: 출발 지점으로!");
                    break;
                }
            case 4:
                {
                    // Socialism: Make Money Equal between Players
                    int MoneySum = TurnManager.Money[0] + TurnManager.Money[1];
                    TurnManager.Money[0] = TurnManager.Money[1] = MoneySum / 2;
                    break;
                }
            case 5:
                {
                    // Evangelism: Make another Player get a Course
                    if (Player == 1)
                    {
                        Inventory.inventory2[Random.Range(0, 10)] = 1;
                    }
                    else
                    {
                        Inventory.inventory1[Random.Range(0, 10)] = 1;
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public static void MapResult(string data)
    {
        RollDice.ResultController.SetActive(true);
        GameObject.Find("MapResultText").GetComponent<Text>().text = data;
        
        mSelf.StartCoroutine(ResultCycleControl());
    }

    static IEnumerator ResultCycleControl()
    {
        yield return new WaitForSeconds(2);
        RollDice.ResultController.SetActive(false);
    }

    static IEnumerator MoveCycleControl(int x)
    {
        yield return new WaitForSeconds(1);
        switch (x)
        {
            case 1:
                {
                    GameObject.Find("Ladder1").SetActive(false);
                    break;
                }
            case 2:
                {
                    GameObject.Find("Ladder2").SetActive(false);
                    break;
                }
            case 3:
                {
                    GameObject.Find("Ladder3").SetActive(false);
                    break;
                }
            case 4:
                {
                    GameObject.Find("Ladder4").SetActive(false);
                    break;
                }
        }
    }
}
