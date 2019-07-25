using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public static int[] Money = new int[] { 1000, 1000 };
    
    public static void TurnManagement(int Player, int DiceValue)
    {
        int NewPlace = CharacterPosition.MovePlayer(Player, DiceValue);
        MapAction.PlaceAction(Player, NewPlace);
    }
}
