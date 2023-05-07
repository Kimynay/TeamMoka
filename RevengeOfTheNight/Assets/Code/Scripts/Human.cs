using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private GameManager GM;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject human;
    [SerializeField] private GameObject[] movePoints;
    [SerializeField] private GameObject[] teleporters;
    private float breakTime = 0.1f;
    public int target;
    //[SerializeField] private int controllerNumber;
    public bool isMoving = true;
    private float speed = 1.0f;
    public bool canTp=true;
    private bool facingRight = true;

    // Start is called before the first frame update
     private void Awake()
    {
        nextAction();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,new Vector2(movePoints[target].transform.position.x,transform.position.y),step);
            if (transform.position.x-movePoints[target].transform.position.x<0 && !facingRight)
            {
                flipHuman();
            }
            
            if (transform.position.x-movePoints[target].transform.position.x>0 && facingRight)
            {
                flipHuman();
            }
        }
    }

    private void flipHuman()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
        if (facingRight) facingRight=false;
        else facingRight=true;
    }

    /*
    public void nextAction()
    {
        if (heardNoise){}
        else
            if (Random.Range(0.0f,10.0f)>5.0f)
            {
                animator.SetBool("isWalking",true);
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
                if (isMoving) flipHuman();
                isMoving=false;
                animator.SetBool("isWalking",false);
                Invoke("nextAction",breakTime);
            }
    }
    */
    public void nextAction()
    {
        if (GM.playerPosition==GM.humanPosition)
        {
            if (isMoving) flipHuman();
            isMoving=false;
            animator.SetBool("isWalking",false);
            Invoke("nextAction",breakTime);
        }
            else
            {
            if (GM.heardNoise&&GM.playerPosition!=0)
            {
                if (GM.playerFloor!=GM.humanFloor)
                {
                    if (GM.humanFloor==3)
                    {
                        if (target==18)
                        {
                            transform.position = teleporters[2].transform.position;
                            target=11;
                            GM.heardNoise=false;
                            animator.SetBool("isWalking",true);
                            isMoving=true;
                        }
                        else 
                        {
                            GM.heardNoise=false;
                            animator.SetBool("isWalking",true);
                            isMoving=true;
                            target=18;
                        }
                    }
                    else if (GM.humanFloor==1)
                    {
                        if (target==2)
                        {
                            transform.position = teleporters[1].transform.position;
                            target=10;
                            GM.heardNoise=false;
                            animator.SetBool("isWalking",true);
                            isMoving=true;
                        }
                        else 
                        {
                            GM.heardNoise=false;
                            animator.SetBool("isWalking",true);
                            isMoving=true;
                            target=18;
                        }
                    }
                    else if (GM.humanFloor==2)
                    {
                        if (GM.playerFloor==1)
                        {
                            if (target==9)
                            {
                                transform.position = teleporters[0].transform.position;
                                target=3;
                                GM.heardNoise=false;
                                animator.SetBool("isWalking",true);
                                isMoving=true;
                            }
                            else 
                            {
                                GM.heardNoise=false;
                                animator.SetBool("isWalking",true);
                                isMoving=true;
                                target=9;
                            }
                        }
                        else
                        {
                            if (target==12)
                            {
                                transform.position = teleporters[3].transform.position;
                                target=3;
                                GM.heardNoise=false;
                                animator.SetBool("isWalking",true);
                                isMoving=true;
                            }
                            else 
                            {
                                GM.heardNoise=false;
                                animator.SetBool("isWalking",true);
                                isMoving=true;
                                target=12;
                            }
                        }
                    }
                }
                else
                {
                    if (GM.playerPosition==1)
                    {
                        GM.heardNoise=false;
                        isMoving=true;
                        animator.SetBool("isWalking",true);
                        target=0;
                    }
                    else if (GM.playerPosition==2)
                    {
                        GM.heardNoise=false;
                        isMoving=true;
                        animator.SetBool("isWalking",true);
                        target=2;
                    }
                    else if (GM.playerPosition==3)
                    {
                        GM.heardNoise=false;
                        isMoving=true;
                        animator.SetBool("isWalking",true);
                        target=4;
                    }
                    else if (GM.playerPosition==4)
                    {
                        GM.heardNoise=false;
                        isMoving=true;
                        animator.SetBool("isWalking",true);
                        target=6;
                    }
                    else if (GM.playerPosition==5)
                    {
                        GM.heardNoise=false;
                        isMoving=true;
                        animator.SetBool("isWalking",true);
                        target=7;
                    }
                    else if (GM.playerPosition==6)
                    {
                        GM.heardNoise=false;
                        isMoving=true;
                        animator.SetBool("isWalking",true);
                        target=10;
                    }
                    else if (GM.playerPosition==7)
                    {
                        GM.heardNoise=false;
                        isMoving=true;
                        animator.SetBool("isWalking",true);
                        target=11;
                    }
                    else if (GM.playerPosition==8)
                    {
                        GM.heardNoise=false;
                        isMoving=true;
                        animator.SetBool("isWalking",true);
                        target=13;
                    }
                    else if (GM.playerPosition==9)
                    {
                        GM.heardNoise=false;
                        isMoving=true;
                        animator.SetBool("isWalking",true);
                        target=15;
                    }
                    else if (GM.playerPosition==10)
                    {
                        GM.heardNoise=false;
                        isMoving=true;
                        animator.SetBool("isWalking",true);
                        target=17;
                    }
                    
                }
            }
            else
            {
                if (Random.Range(0.0f,10.0f)>5.0f)
                {
                    animator.SetBool("isWalking",true);
                    isMoving=true;
                    if (target==0)
                    {
                        target=1;
                    }
                    else if (target==1)
                    {
                        if (Random.Range(0.0f,10.0f)>5.0f) target=0;
                        else target=2;
                    }
                    else if (target==2)
                    {
                        transform.position = teleporters[1].transform.position;
                        if (Random.Range(0.0f,10.0f)>5.0f) target=8;
                        else target=10;
                    }
                    else if (target==3)
                    {
                        if (Random.Range(0.0f,10.0f)>5.0f) target=2;
                        else target=4;
                    }
                    else if (target==4)
                    {
                        if (Random.Range(0.0f,10.0f)>5.0f) target=3;
                        else target=5;
                    }
                    else if (target==5)
                    {
                        if (Random.Range(0.0f,10.0f)>5.0f) target=4;
                        else target=6;
                    }
                    else if (target==6)
                    {
                        target=5;
                    }
                    else if (target==7)
                    {
                        target=8;
                    }
                    else if (target==8)
                    {
                        if (Random.Range(0.0f,10.0f)>5.0f) target=7;
                        else target=9;
                    }
                    else if (target==9)
                    {
                        transform.position = teleporters[0].transform.position;
                        if (Random.Range(0.0f,10.0f)>5.0f) target=1;
                        else target=3;
                    }
                    else if (target==10)
                    {
                        if (Random.Range(0.0f,10.0f)>5.0f) target=9;
                        else target=11;
                    }
                    else if (target==11)
                    {
                        if (Random.Range(0.0f,10.0f)>5.0f) target=10;
                        else target=12;
                    }
                    else if (target==12)
                    {
                        transform.position = teleporters[3].transform.position;
                        target=17;
                    }
                    else if (target==13)
                    {
                        target=14;
                    }
                    else if (target==14)
                    {
                        if (Random.Range(0.0f,10.0f)>5.0f) target=13;
                        else target=15;
                    }
                    else if (target==15)
                    {
                        if (Random.Range(0.0f,10.0f)>5.0f) target=14;
                        else target=16;
                    }
                    else if (target==16)
                    {
                        if (Random.Range(0.0f,10.0f)>5.0f) target=15;
                        else target=17;
                    }
                    else if (target==17)
                    {
                        if (Random.Range(0.0f,10.0f)>5.0f) target=16;
                        else target=18;
                    }
                    else if (target==18)
                    {
                        transform.position = teleporters[2].transform.position;
                        target=11;
                    }
                }
                else
                {
                    if (isMoving) flipHuman();
                    isMoving=false;
                    animator.SetBool("isWalking",false);
                    Invoke("nextAction",breakTime);
                }
            }
        }
    }

}
