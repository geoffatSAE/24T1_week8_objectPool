using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGHPool : MonoBehaviour
{
    public GHObjectPool ghObjectPool;

    float timer;
    public float fireRate;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            FireNow();
            timer = 0.0f;
        }
    }

    void FireNow()
    {

        //GameObject canonBall = Instantiate(cannonball) as GameObject;
        //get a canonball
        GameObject shootCannonBall = ghObjectPool.GetCannonBall();

        //activate
       // shootCannonBall.SetActive(true);
        shootCannonBall.transform.position = new Vector3(-6.8f, 1.52f, 0f);
        Rigidbody ri = shootCannonBall.GetComponent<Rigidbody>();
        ri.AddForce(new Vector3(2000, 1000, Random.Range(0, 100)));

    }
}
