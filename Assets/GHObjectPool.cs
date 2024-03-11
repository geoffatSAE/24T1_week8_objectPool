using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GHObjectPool : MonoBehaviour
{

    public GameObject[] cannonBalls;
    public GameObject cannonBallPrefab;
    public int maxCannonBalls;
    int lastUsed;

    // Start is called before the first frame update
    void Start()
    {
        //initialise
        cannonBalls = new GameObject[maxCannonBalls];

        //assign the gameObjects
        for (int i = 0; i < maxCannonBalls; i++)
        {
            cannonBalls[i] = Instantiate(cannonBallPrefab) as GameObject;
            cannonBalls[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetCannonBall()
    {
        int returningIndex = lastUsed;
        lastUsed++;
        if (lastUsed == maxCannonBalls) lastUsed = 0; //wrap back around to the first if we've hit the last

        //active the cannonBall, first check if it's already active
        if(cannonBalls[returningIndex].active == true)
        {
            //it is already active, reset it's motion (or in other cases we're run a reset function)
            Rigidbody rb = cannonBalls[returningIndex].GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            //might put a timeout function here also. Add to the objects own class
        } else
        {
            cannonBalls[returningIndex].SetActive(true);

        }
        return cannonBalls[returningIndex];
    }
}
