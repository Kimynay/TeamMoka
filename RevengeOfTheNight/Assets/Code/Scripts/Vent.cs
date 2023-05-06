using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{

    [SerializeField] private GameObject teleportTarget;

    void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = teleportTarget.transform.position;
    }
}
