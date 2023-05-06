using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private GameObject human;
    [SerializeField] private GameObject[] movePoints;
    private float breakTime = 0.1f;
    public int target;
    //[SerializeField] private int controllerNumber;
    public bool isMoving = true;
    public float speed = 3.0f;
    private bool heardNoise = false;
    public bool canTp=true;

    // Start is called before the first frame update
    void Start()
    {
        target = 15;
        nextAction();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,new Vector2(movePoints[target].transform.position.x,transform.position.y),step);
        }
    }

    public void nextAction()
    {
        if (heardNoise){}
        else
            if (Random.Range(0.0f,10.0f)>5.0f)
            {
                isMoving=true;
                if (target==1 || target==2 || target==3 || target==4 || target==7 || target==8 || target==11 || target==12 || target==13|| target==14)
                {
                    if (Random.Range(0.0f,10.0f)>5.0f)
                    {
                        target+=1;
                    }
                    else
                    {
                        target-=1;
                    }
                }
                else
                    if (target==0) 
                    {
                        target+=1;
                    }
                    else
                        if (target==5 || target == 9)
                        {
                            target+=2;
                        }
                        else
                            if (target==15)
                            {
                                target-=1;
                            }
                            else
                            {
                                target-=2;
                            }
                        
            }
            else
            {
                isMoving=false;
                Invoke("nextAction",breakTime);
            }
    }
}
