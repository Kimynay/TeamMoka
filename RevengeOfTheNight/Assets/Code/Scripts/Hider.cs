using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hider : MonoBehaviour
    
{
    private SpriteRenderer m;
    [SerializeField] private int roomNumber;
    [SerializeField] private GameManager GM;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == 8)
        {
            m =gameObject.GetComponent<SpriteRenderer>();
            m.enabled = false;
            GM.setPlayerPosition(roomNumber);
        }
        if (other.gameObject.layer == 10)
        {
            GM.setHumanPosition(roomNumber);
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.layer == 8)
        {
         m =gameObject.GetComponent<SpriteRenderer>();
         m.enabled = true;
        }
    }
}
