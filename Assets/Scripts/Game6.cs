using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game6 : MonoBehaviour
{
    static float TimeLeft, nextTime;
    static int background, result;
    
    // Start is called before the first frame update
    void Start()
    {
        background = 0;
        TimeLeft = 1.0f;
        nextTime = 1.0f;
        GameObject.Find("Canvas").transform.Find("Button").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("095958").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("095959").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Front").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Waiting").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Result1").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Result2").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Result3").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Result4").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Result5").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (background < 3 && Time.time > nextTime)
        {
            nextTime = Time.time + TimeLeft;
            BackgroundChange();
        }
    }

    void BackgroundChange()
    {
        switch (background)
        {
            case 0:
                {
                    GameObject.Find("Canvas").transform.Find("095958").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("095957").gameObject.SetActive(false);
                    background++;
                    break;
                }
            case 1:
                {
                    GameObject.Find("Canvas").transform.Find("095959").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("095958").gameObject.SetActive(false);
                    background++;
                    break;
                }
            case 2:
                {
                    GameObject.Find("Canvas").transform.Find("Front").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("Button").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("095959").gameObject.SetActive(false);
                    background++;
                    break;
                }
        }
    }

    public void ClickButton()
    {
        float score = Time.time - 4.0f;
        if (score < 1.0f) result = 5;
        else if (score < 1.5f) result = 4;
        else if (score < 2.0f) result = 3;
        else if (score < 2.5f) result = 2;
        else result = 1;

        GameObject.Find("Canvas").transform.Find("Waiting").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Front").gameObject.SetActive(false);

        StartCoroutine(ClickCycleControl());
    }

    static IEnumerator ClickCycleControl()
    {
        yield return new WaitForSeconds(12);
        GameObject.Find("Canvas").transform.Find("Result" + result.ToString()).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Waiting").gameObject.SetActive(false);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMap");
    }
}
