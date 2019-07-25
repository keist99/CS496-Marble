using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public Slider scorebar;
    public Text SliderScore;

    public static int score, barscore, barmaxscore;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        SliderScore.text = score.ToString();
        scorebar.maxValue = 100;
        scorebar.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        SliderScore.text = score.ToString();
    }
}
