using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomGame : MonoBehaviour
{
    public Text Result;
    public static int Player;
    int ValueA, ValueB, ValueC;
    bool possible = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeValue()
    {
        ValueA = Random.Range(1, 1000);
        ValueB = Random.Range(1, 1000);
        ValueC = Random.Range(1, 1000);
    }

    public void DoA()
    {
        if (possible)
        {
            possible = false;
            MakeValue();
            Result.text = "Result: " + ValueA.ToString();
            TurnManager.Money[Player - 1] += ValueA;
            StartCoroutine(ResultCycleControl());
        }
    }

    public void DoB()
    {
        if (possible)
        {
            possible = false;
            MakeValue();
            Result.text = "Result: " + ValueB.ToString();
            TurnManager.Money[Player - 1] += ValueB;
            StartCoroutine(ResultCycleControl());
        }
    }

    public void DoC()
    {
        if (possible)
        {
            possible = false;
            MakeValue();
            Result.text = "Result: " + ValueC.ToString();
            TurnManager.Money[Player - 1] += ValueC;
            StartCoroutine(ResultCycleControl());
        }
    }

    IEnumerator ResultCycleControl()
    {
        yield return new WaitForSeconds(2);
        possible = true;
        SceneManager.LoadScene("MainMap");
    }
}
