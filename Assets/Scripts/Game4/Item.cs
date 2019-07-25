using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Item : MonoBehaviour
{
    public bool win = false;
    //Button
    private Vector3 targetPosition;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name== "jumphigh")
        {
            Destroy(col.gameObject);
            soundManager.instance.PlaySound();
        }
        if (col.gameObject.name == "cube"){
            win = true;
            SceneManager.LoadScene("MainMap");
            TurnManager.Money[RollDice.Player - 1] += 2000;
        }
            
        

    }
}
