using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{


    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Sea")
        {
            Destroy(gameObject);
        }
        if(col.gameObject.name == "Terrain")
        {
            Destroy(gameObject);
        }
        
    }
}
