using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RollDice : MonoBehaviour
{
    public Sprite Dice1;
    public Sprite Dice2;
    public Sprite Dice3;
    public Sprite Dice4;
    public Sprite Dice5;
    public Sprite Dice6;
    public Button Dice;

    GameObject DiceController;
    public static GameObject ResultController;

    public static int DiceValue, Player;
    public static bool DiceRollable;
    public static int[] RestTurn;

    void Start()
    {
        Player = 1;
        RestTurn = new int[] { 0, 0 };
        DiceRollable = true;
        DiceController = GameObject.Find("Dice");
        ResultController = GameObject.Find("MapResult");
        DiceController.SetActive(false);
        ResultController.SetActive(false);

        GameObject.Find("Ladder1").SetActive(false);
        GameObject.Find("Ladder2").SetActive(false);
        GameObject.Find("Ladder3").SetActive(false);
        GameObject.Find("Ladder4").SetActive(false);
        GameObject.Find("Course1").SetActive(false);
        GameObject.Find("Course2").SetActive(false);
        GameObject.Find("Course3").SetActive(false);
        GameObject.Find("Course4").SetActive(false);
        GameObject.Find("Course5").SetActive(false);
        GameObject.Find("Course6").SetActive(false);
        GameObject.Find("Course7").SetActive(false);
        GameObject.Find("Course8").SetActive(false);
        GameObject.Find("Course9").SetActive(false);
        GameObject.Find("Course10").SetActive(false);

        GameObject.Find("character1").transform.position = new Vector3(CharacterPosition.PositionX[CharacterPosition.PlayerPosA] + 960, CharacterPosition.PositionY[CharacterPosition.PlayerPosA] + 540, 0);
        GameObject.Find("character2").transform.position = new Vector3(CharacterPosition.PositionX[CharacterPosition.PlayerPosB] + 960, CharacterPosition.PositionY[CharacterPosition.PlayerPosB] + 540, 0);
    }
    
    void Update()
    {
        if (Player == 1)
        {
            if (Inventory.inventory1[0] == 1) GameObject.Find("Canvas").transform.Find("Course1").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course1").gameObject.SetActive(false);
            if (Inventory.inventory1[1] == 1) GameObject.Find("Canvas").transform.Find("Course2").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course2").gameObject.SetActive(false);
            if (Inventory.inventory1[2] == 1) GameObject.Find("Canvas").transform.Find("Course3").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course3").gameObject.SetActive(false);
            if (Inventory.inventory1[3] == 1) GameObject.Find("Canvas").transform.Find("Course4").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course4").gameObject.SetActive(false);
            if (Inventory.inventory1[4] == 1) GameObject.Find("Canvas").transform.Find("Course5").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course5").gameObject.SetActive(false);
            if (Inventory.inventory1[5] == 1) GameObject.Find("Canvas").transform.Find("Course6").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course6").gameObject.SetActive(false);
            if (Inventory.inventory1[6] == 1) GameObject.Find("Canvas").transform.Find("Course7").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course7").gameObject.SetActive(false);
            if (Inventory.inventory1[7] == 1) GameObject.Find("Canvas").transform.Find("Course8").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course8").gameObject.SetActive(false);
            if (Inventory.inventory1[8] == 1) GameObject.Find("Canvas").transform.Find("Course9").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course9").gameObject.SetActive(false);
            if (Inventory.inventory1[9] == 1) GameObject.Find("Canvas").transform.Find("Course10").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course10").gameObject.SetActive(false);
        }
        else
        {
            if (Inventory.inventory2[0] == 1) GameObject.Find("Canvas").transform.Find("Course1").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course1").gameObject.SetActive(false);
            if (Inventory.inventory2[1] == 1) GameObject.Find("Canvas").transform.Find("Course2").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course2").gameObject.SetActive(false);
            if (Inventory.inventory2[2] == 1) GameObject.Find("Canvas").transform.Find("Course3").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course3").gameObject.SetActive(false);
            if (Inventory.inventory2[3] == 1) GameObject.Find("Canvas").transform.Find("Course4").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course4").gameObject.SetActive(false);
            if (Inventory.inventory2[4] == 1) GameObject.Find("Canvas").transform.Find("Course5").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course5").gameObject.SetActive(false);
            if (Inventory.inventory2[5] == 1) GameObject.Find("Canvas").transform.Find("Course6").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course6").gameObject.SetActive(false);
            if (Inventory.inventory2[6] == 1) GameObject.Find("Canvas").transform.Find("Course7").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course7").gameObject.SetActive(false);
            if (Inventory.inventory2[7] == 1) GameObject.Find("Canvas").transform.Find("Course8").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course8").gameObject.SetActive(false);
            if (Inventory.inventory2[8] == 1) GameObject.Find("Canvas").transform.Find("Course9").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course9").gameObject.SetActive(false);
            if (Inventory.inventory2[9] == 1) GameObject.Find("Canvas").transform.Find("Course10").gameObject.SetActive(true);
            else GameObject.Find("Canvas").transform.Find("Course10").gameObject.SetActive(false);
        }
    }

    public void DiceRoller()
    {
        if (DiceRollable)
        {
            if (RestTurn[Player - 1] == 0)
            {
                DiceRollable = false;
                DiceRoll();
                DiceRollable = true;
            }
            else
            {
                RestTurn[Player - 1]--;
            }
        }
    }
    void DiceRoll()
    {
        DiceValue = Random.Range(1, 7);
        switch (DiceValue)
        {
            case 1:
                Dice.image.sprite = Dice1;
                break;
            case 2:
                Dice.image.sprite = Dice2;
                break;
            case 3:
                Dice.image.sprite = Dice3;
                break;
            case 4:
                Dice.image.sprite = Dice4;
                break;
            case 5:
                Dice.image.sprite = Dice5;
                break;
            case 6:
                Dice.image.sprite = Dice6;
                break;
        }

        DiceController.SetActive(true);
        StartCoroutine(DiceCycleControl());
        TurnManager.TurnManagement(Player, DiceValue);

        Player = (Player == 1) ? 2 : 1;
    }

    IEnumerator DiceCycleControl()
    {
        yield return new WaitForSeconds(2);
        DiceController.SetActive(false);
    }
}
