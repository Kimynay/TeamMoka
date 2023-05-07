using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    [SerializeField] private int roomNumber;
    [SerializeField] private GameManager GM;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == 8)
        {
            GM.setPlayerPosition(roomNumber);
        }
        if (other.gameObject.layer == 10)
        {
            GM.setHumanPosition(roomNumber);
        }
    }
}
