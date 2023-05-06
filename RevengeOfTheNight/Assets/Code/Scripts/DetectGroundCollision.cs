using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGroundCollision : MonoBehaviour
{
    private BreakableItem parentScript;
    void Start()
    {
        parentScript = transform.parent.gameObject.GetComponent<BreakableItem>();
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Something ?");
    //    if(collision.gameObject.CompareTag("Wall"))
    //    {
    //        parentScript.Break();
    //    }
    //}   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            parentScript.Break();
        }
    }
    void Update()
    {

    }

}
