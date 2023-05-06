using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ping : MonoBehaviour
{
    private bool ping=true;
    private float pingPeriod = 1f;
    Vector3 localScale;
    private float pingSpeed=0.45f;
    [SerializeField] GameObject human;
    private SpriteRenderer m;
    private float pingSize = 0.4f;
    
    [SerializeField] GameObject secondPing;

    // Update is called once per frame
    void Update()
    {
        if (ping)
        {
            if (transform.localScale.x<pingSize/2)
            {
                localScale = transform.localScale;
                localScale +=new Vector3(1,1,1)*Time.deltaTime*pingSpeed;
                transform.localScale = localScale;
            }
            else
            {
                localScale = transform.localScale;
                localScale +=new Vector3(1,1,1)*Time.deltaTime*pingSpeed*1f;
                transform.localScale = localScale;
            }
            if (transform.localScale.x>pingSize*0.55f)
            {
                m =secondPing.GetComponent<SpriteRenderer>();
                m.enabled = true;
            }
            if (transform.localScale.x>pingSize*0.8f)
            {
                m =gameObject.GetComponent<SpriteRenderer>();
                m.enabled = false;
            }
            if (transform.localScale.x>pingSize*1.2)
            {
                localScale =new Vector3(0.05f,0.05f,1f);
                transform.localScale = localScale;
                ping=false;
                Invoke("startPing",pingPeriod);
                m =secondPing.GetComponent<SpriteRenderer>();
                m.enabled = false;
            }

        }
        
    }

    private void startPing()
    {
        transform.position = human.transform.position;
        ping=true;
        m =gameObject.GetComponent<SpriteRenderer>();
        m.enabled = true;
    }
}
