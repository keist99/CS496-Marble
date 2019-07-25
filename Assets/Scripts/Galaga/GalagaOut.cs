using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalagaOut : MonoBehaviour
{
    public static void Finish()
    {
        int Player = RollDice.Player;
        TurnManager.Money[Player - 1] += ScoreBar.score / 100;
        SceneManager.LoadScene("MainMap");
    }
}
