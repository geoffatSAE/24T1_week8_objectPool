using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Renderer r = GetComponent<Renderer>();
        r.material.color = Color.yellow;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Movement() //move function
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        

        //Debug.Log(horizontal + " and " + vertical);
        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * speed);
        //transform.Rotate(0.0f, horizontal, 0.0f, Space.Self);

    }
}
