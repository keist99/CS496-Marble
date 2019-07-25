using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
public class copypaste : MonoBehaviour
{
    public GameObject cube;
    public Material material;
    // Start is called before the first frame update
    public float x;
    public float z;
    //Renderer rend;
    private float y = 6;
    public System.Random rand = new System.Random();
    //new Rigidbody rigidbody;
    public int[,] arr = new int[10, 11];
    public GameObject[,] copy = new GameObject[10, 11];
    Vector3 movement;
    public int randNum;
    public float speed = 2f;
    float nextTime = 0;
    int interval = 3;
    public float time = 0.0f;
    public float period = 1000f;
    bool first = true;
    //Rigidbody[,] rigidArray = new Rigidbody[10,11];
    //public float speed = (float );
    private Vector3 StartPosition;
    private Vector3 EndPosition;
    private Vector3 temp;
    // Update is called once per frame
    void Start()
    {
       
        for (float a = 0; a <= 90; a = a + 10)
        {
            for (float b = 0; b >= -100; b = b - 10)
            {

                if (z + b == -x - a + 5)
                {
                    continue;
                }
                if (a == 90 && b == 0)
                {
                    continue;
                }
                else if (a == 0 && b == -100)
                {
                    continue;
                }
                /*int temp = Random.Range(0, 2);
                if (temp == 0)
                {
                    continue;
                }*/

                copy[(int)a / 10, (int)(b * -1) / 10] = Instantiate(cube, new Vector3(x + a, y, z + b), Quaternion.identity) as GameObject;
                copy[(int)a / 10, (int)(b * -1) / 10].GetComponent<Renderer>().material = material;
                //rigidArray[(int)a / 10, (int)(b * -1) / 10] = copy[(int)a / 10, (int)(b * -1) / 10].AddComponent<Rigidbody>();
                arr[(int)a / 10, (int)(b * -1) / 10] = 1;
            }
        }
        InvokeRepeating("UpdatePerSecond", 0, (float)1.0);
        //InvokeRepeating("UpdatePerSecond", 0, (float)1.0);
    }






    /*private void FixedUpdate()
    {
        
    }*/
    //private void Update()
    //{
        //random = 
        /*if (time >= period)
        {
            Debug.Log("why..");
            Console.WriteLine(time);
            time = time - period;
           
        
        }
        else
        {
            Debug.Log("this must be occur");
        }
        time = time + Time.deltaTime;

        //WaitForIt();*/


    //}
private void UpdatePerSecond()
    {
         for(int i = 0; i< 10; i++)
            {
                for (int j = 0; j< 11; j++)
                {
                    randNum = rand.Next(0, 2);
                    if (z + j* -10 == -x - 10 * i + 5)
                    {
                        continue;
                    }
                    if (i == 9 && j == 0)
                    {
                        continue;
                    }
                    else if (i == 0 && j == -10)
                    {
                        continue;
                    }
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
      
    /*IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(3f);
    }*/
    private void Godown(int i, int j)
    {

        if (copy[i, j] == null)
        {

            return;
        }
  

        temp = new Vector3(x + 10 * i, (float)-4, z - 10 * j);
        copy[i,j].transform.position = Vector3.Lerp(copy[i,j].transform.position,temp,(float)0.5f);
      
    }
    private void Goup(int i, int j)
    {
        if (copy[i, j] == null)
        {

            return;
        }
      
        temp = new Vector3(x + 10 * i, (float)6, z - 10 * j);
        copy[i, j].transform.position = Vector3.Lerp(copy[i, j].transform.position, temp, (float)0.5f);
      
    }

}