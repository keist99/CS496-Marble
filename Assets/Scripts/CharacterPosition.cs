using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPosition : MonoBehaviour
{
    public static int PlayerPosA = 1, PlayerPosB = 1;
    public static int[] PositionX = new int[] { 0, -850, -665, -520, -370, -220, -75, 75, 220, 370, 520, 665, 850,
                                            850, 850, 850, 850, 850,
                                            850, 665, 520, 370, 220, 75, -75, -220, -370, -520, -665, -850,
                                            -850, -850, -850, -850, -850 };
    public static int[] PositionY = new int[] { 0, 430, 430, 430, 430, 430, 430, 430, 430, 430, 430, 430, 430,
                                            350, 215, 30, -35, -170,
                                            -430, -430, -430, -430, -430, -430, -430, -430, -430, -430, -430, -430,
                                            -170, -35, 90, 215, 350 };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int MovePlayer(int Player, int DiceValue)
    {
        if (Player == 1)
        {
            PlayerPosA += DiceValue;
            if (PlayerPosA > 34)
            {
                PlayerPosA -= 34;
                TurnManager.Money[0] += 500;
            }
            GameObject.Find("character1").transform.position = new Vector3(PositionX[PlayerPosA] + 960, PositionY[PlayerPosA] + 540, 0);
            return PlayerPosA;
        }
        else if (Player == 2)
        {
            PlayerPosB += DiceValue;
            if (PlayerPosB > 34)
            {
                PlayerPosB -= 34;
                TurnManager.Money[1] += 500;
            }
            GameObject.Find("character2").transform.position = new Vector3(PositionX[PlayerPosB] + 960, PositionY[PlayerPosB] + 540, 0);
            return PlayerPosB;
        }
        else return 0;
    }
}
