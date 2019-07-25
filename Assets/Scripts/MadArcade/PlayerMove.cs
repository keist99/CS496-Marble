using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 direction = collision.gameObject.transform.position - transform.position;

        if (direction.x < -50)
        {
            MadArcade.moveleftpossible = false;
        }
        else if (direction.x > 50)
        {
            MadArcade.moverightpossible = false;
        }

        if (direction.y < -50)
        {
            MadArcade.movedownpossible = false;
        }
        else if (direction.y > 50)
        {
            MadArcade.moveuppossible = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MadArcade.moveleftpossible = true;
        MadArcade.moverightpossible = true;
        MadArcade.moveuppossible = true;
        MadArcade.movedownpossible = true;
    }
}
