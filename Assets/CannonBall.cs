using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CannonBall : MonoBehaviour
{

    //this script managed the CanonBall to ensure it is usable for a Pool Object
    //We might for example use this with a StateMachine

    //
    private IObjectPool<CannonBall> objectPool;
    //public property to give the cannonball a reference to it's object pool
    public IObjectPool<CannonBall> ObjectPool { set => objectPool = value;  }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
