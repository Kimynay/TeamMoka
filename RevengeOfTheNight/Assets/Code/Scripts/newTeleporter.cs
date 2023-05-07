using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newTeleporter : MonoBehaviour
{

    [SerializeField] private GameObject teleportTarget;
    [SerializeField] private GameObject player;
    private bool canTP=false;

    private void Update()
    {
        if (Input.GetKeyDown("a") && canTP)
        {
            player.transform.position=teleportTarget.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            canTP=true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            canTP=false;
        }
    }
}
