using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copypaste2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cube;
    // Start is called before the first frame update
    public float x;
    public float z;
    float y = 6;
    System.Random rand = new System.Random();
    int randNum;
    public GameObject[,] copy = new GameObject[11, 10];
    public int[,] arr = new int[11, 10];
    // Update is called once per frame
    float nextTime = 0;
    int interval = 3;
    private float time = 0.1f;
    public float period = 20f;
    Vector3 temp;
    void Start()
    {
        for (float a = 0; a <= 100; a = a + 10)
        {
            for (float b = 0; b >= -90; b = b - 10)
            {
                if (z + b == -x - a + 5)
                {
                    continue;
                }
                /*if (a == 90 && b == 0)
                {
                    continue;
                }
                else if(a==0&& b == -90)
                {
                    continue;
                }*/
                //int temp = Random.Range(0, 2);
                /*if (temp == 0)
                {
                    continue;
                }*/
                copy[(int)a / 10, (int)(b * -1) / 10] = Instantiate(cube, new Vector3(x + a, y, z + b), Quaternion.identity) as GameObject;
                arr[(int)a / 10, (int)(b * -1) / 10] = 1;
            }
        }
        InvokeRepeating("UpdatePerSecond", 0, (float)1.0);
    }
    private void UpdatePerSecond()
    {
        //random = 
        
           
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    randNum = rand.Next(0, 2);
                    if (z - 10 * j == -x + 10 * i + 5)
                    {
                        continue;
                    }
                    /*if (i == 9 && j == 0)
                    {
                        continue;
                    }
                    else if (i == 0 && j == -10)
                    {
                        continue;
                    }*/
                    //0 없음 1 있음 copy 인덱스 i,j
                    if (arr[i, j] == randNum)
                    {
                        continue;
                    }
                    else if (arr[i, j] == 1 && randNum == 0) //1->0
                    {
                        Godown(i, j);
                        arr[i, j] = randNum;
                    }
                    else//0->1
                    {
                        Goup(i, j);
                        arr[i, j] = randNum;
                    }
                }
            }
        
       
     
    }
    private void Godown(int i, int j)
    {

        if (copy[i, j] == null)
        {

            return;
        }
        /*if (copy[i, j].transform.position.y <= -15) {

            return;
        }//6-20*/

        temp = new Vector3(x + 10 * i, (float)-20, z - 10 * j);
        //(x + 10 * i, (float)-15, z + 10 * j) public temp;
        //copy[i, j].transform.Translate(Vector3.down* 1*speed);
        copy[i, j].transform.position = Vector3.Lerp(copy[i, j].transform.position, temp, 0.5f);
        //Debug.Log(Time.deltaTime);
        //Thread.Sleep(100);
    }
    private void Goup(int i, int j)
    {
        //float currentTime = 0f;
        //float maxTime = (6-copy[i, j].transform.position.y)/50;
        if (copy[i, j] == null)
        {

            return;
        }
        /*if (copy[i, j].transform.position.y <= -15) {

            return;
        }//6-20*/

        temp = new Vector3(x + 10 * i, (float)16, z - 10 * j);
        //(x + 10 * i, (float)-15, z + 10 * j) public temp;
        //copy[i, j].transform.Translate(Vector3.down* 1*speed);
        /*while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
           
        }*/
        copy[i, j].transform.position = Vector3.Lerp(copy[i, j].transform.position, temp, 0.5f);
        //Debug.Log(Time.deltaTime);
        //Thread.Sleep(100);

    }
}
