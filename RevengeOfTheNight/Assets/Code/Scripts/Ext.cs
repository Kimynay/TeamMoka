using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ext : MonoBehaviour
{
    [SerializeField] private GameManager GM;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == 8)
        {
            GM.setPlayerPosition(0);
            GM.deZoom();
        }
    }
}
