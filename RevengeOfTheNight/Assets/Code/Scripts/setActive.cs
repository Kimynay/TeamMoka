using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setActive : MonoBehaviour
{
    [SerializeField] private GameObject o;
    
    void Start()
    {
        o.SetActive(true);
    }
}
