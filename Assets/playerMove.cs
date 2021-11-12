using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    //a vector 3 for position
    Vector3 vec;

    // Update is called once per frame
    void Update()
    {   
        //not moving
        vec = transform.localPosition;
        vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * 20;
    }
}
