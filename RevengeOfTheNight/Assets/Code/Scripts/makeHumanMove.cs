using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeHumanMove : MonoBehaviour
{
   [SerializeField] private Human human; 
   [SerializeField] private int targetNumber;
   private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.layer == 10)
    {
        if (targetNumber==human.target)
        {
            human.nextAction();
        }
    }
   }
}
