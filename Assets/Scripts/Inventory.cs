using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public static int[] inventory1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int[] inventory2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    // 순서: 프밍기, 논설, 시프, 자구, AI, 네트워크, 그래픽스, OS, 확률, 컴구

    public static void addRandom(int Player)
    {
        int access = Random.Range(0, 5);
        if (Player == 1) inventory1[access] = 1;
        else inventory2[access] = 1;
    }

    public static void search(int subject, int Player) // only hubo
    {
        if (Player == 1)
        {
            if (inventory1[subject - 1] == 1) return;
            if (TurnManager.Money[Player - 1] >= 200)
            {
                TurnManager.Money[Player - 1] -= 200;
                inventory1[subject - 1] = 1;
                GameObject.Find("Canvas").transform.Find("Course" + subject.ToString()).gameObject.SetActive(true);
            }

            int sum = 0;
            for (int i = 0; i < 10; i++) sum += inventory1[i];
            if (sum == 10) SceneManager.LoadScene("Winner");
        }
        else
        {
            if (inventory2[subject - 1] == 1) return;
            if (TurnManager.Money[Player - 1] >= 200)
            {
                TurnManager.Money[Player - 1] -= 200;
                inventory2[subject - 1] = 1;
                GameObject.Find("Canvas").transform.Find("Course" + subject.ToString()).gameObject.SetActive(true);
            }

            int sum = 0;
            for (int i = 0; i < 10; i++) sum += inventory2[i];
            if (sum == 10) SceneManager.LoadScene("Winner");
        }
    }
    public static void searchPre(int subject, int Player, int pre)
    {
        if (Player == 1)
        {
            if (inventory1[subject - 1] == 1) return;
            if (TurnManager.Money[Player - 1] >= 500 && inventory1[pre - 1] == 1)
            {
                TurnManager.Money[Player - 1] -= 500;
                inventory1[subject - 1] = 1;
                GameObject.Find("Canvas").transform.Find("Course" + subject.ToString()).gameObject.SetActive(true);
            }

            int sum = 0;
            for (int i = 0; i < 10; i++) sum += inventory1[i];
            if (sum == 10) SceneManager.LoadScene("Winner");
        }
        else
        {
            if (inventory2[subject - 1] == 1) return;
            if (TurnManager.Money[Player - 1] >= 500 && inventory2[pre - 1] == 1)
            {
                TurnManager.Money[Player - 1] -= 500;
                inventory2[subject - 1] = 1;
                GameObject.Find("Canvas").transform.Find("Course" + subject.ToString()).gameObject.SetActive(true);
            }

            int sum = 0;
            for (int i = 0; i < 10; i++) sum += inventory2[i];
            if (sum == 10) SceneManager.LoadScene("Winner");
        }
    }
}
