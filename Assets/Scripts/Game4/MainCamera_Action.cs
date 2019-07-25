using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Action : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    private Vector3 diff;
    public float offsetX;
    public float offsetY;
    public float offsetZ;
    float limit = 3f;
    Vector3 cameraPosition;

    void Start()
    {
        diff = transform.position - Player.transform.position;
        //diff.z = 3;
    }
        private void LateUpdate()
    {
        /*cameraPosition.x = Player.transform.position.x + offsetX;
        cameraPosition.x = Player.transform.position.y + offsetY;
        cameraPosition.z = Player.transform.position.z + offsetZ;
        transform.position = cameraPosition;*/
        if (diff.x < limit*-1)
        {
            diff.x = limit * -1;
        }
        if(diff.x> limit)
        {
            diff.x = limit;
        }
        if (diff.y < limit*-1)
        {
            diff.y = limit * -1;
        }
        if (diff.y > 3f)
        {
            diff.y = limit;
        }
        transform.position = diff + Player.transform.position;
        
    }
}
