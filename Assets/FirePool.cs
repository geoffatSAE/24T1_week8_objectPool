using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FirePool : MonoBehaviour
{

    public CannonBall cannonball; //this is our prefab to shoot
    float timer;
    public float fireRate;

    private IObjectPool<CannonBall> cannonBallObjectPool;
    public int defaultCapacity = 10;
    public int maxSize = 20;
    public bool collectionCheck = true;

    private void Awake()
    {
        cannonBallObjectPool = new ObjectPool<CannonBall>(CreateCannonBall, OnGetFromPool, OnReleaseToPool, OnDestroyPoolObject,
            collectionCheck, defaultCapacity, maxSize);
    }

    private CannonBall CreateCannonBall()
    {
        //instantiates an instance of a cannon ball
        CannonBall cannonBallInstance = Instantiate(cannonball);
        //adds a reference to the object pool we've created on the cannon ball
        cannonBallInstance.ObjectPool = cannonBallObjectPool;
        //return the object we created
        return cannonBallInstance;
    }

    //what we do when we get, return, and destory an item from the pool. In this case set active true and false, could be state machine
    private void OnGetFromPool(CannonBall pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }
    private void OnReleaseToPool (CannonBall pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }
    private void OnDestroyPoolObject(CannonBall pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }

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

        CannonBall canonBall = cannonBallObjectPool.Get(); //GETS A CANNONBALL

        Rigidbody ri = canonBall.gameObject.GetComponent<Rigidbody>();
        canonBall.gameObject.transform.position = new Vector3(-6.8f, 1.52f, 0f);
        ri.AddForce(new Vector3(2000, 1000, Random.Range(0, 100)));

    }
}
