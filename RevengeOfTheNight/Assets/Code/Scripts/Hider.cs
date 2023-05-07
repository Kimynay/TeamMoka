using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hider : MonoBehaviour
    
{
    private SpriteRenderer m;
    [SerializeField] private int floorNumber;
    [SerializeField] private GameManager GM;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == 8)
        {
            m =gameObject.GetComponent<SpriteRenderer>();
            m.enabled = false;
            //GM.setPlayerPosition(roomNumber);
            GM.setPlayerFloor(floorNumber);
            GM.Zoom();
        }
        if (other.gameObject.layer == 10)
        {
            //GM.setHumanPosition(roomNumber);
            GM.setHumanFloor(floorNumber);

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
