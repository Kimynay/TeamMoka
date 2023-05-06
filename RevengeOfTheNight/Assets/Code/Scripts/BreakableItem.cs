using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableItem : MonoBehaviour
{
    //[Range(-1f, 1f)]
    public float currentForce = 0.0f;
    public bool isShaking = false;
    public float maxAngle;
    public float AddedForce = 0.3f;
    public float shakingMaxSpeed = 20;
    public float stabilisationSpeed = 10;
    private GameObject image;
    private float localTime = 0.0f;
    void Start()
    {
        image = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if(isShaking)
        {
            Shake();
            localTime += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isShaking = true;
        AddMaxAngle();
        localTime = 0.0f;
    }

    void Shake()
    {
        if (currentForce > 1.0f)
        {
            Debug.Log("Falliiiiiiiing");
        }
        else
        {
            image.transform.rotation = Quaternion.Euler(0, 0, (currentForce * maxAngle) * Mathf.Sin(localTime * (shakingMaxSpeed * Mathf.Abs(currentForce - 1.0f))));
            currentForce -= Time.deltaTime / stabilisationSpeed;
            if (currentForce <= 0.01f)
            {
                currentForce = 0.0f;
                image.transform.rotation = Quaternion.Euler(0, 0, 0);
                isShaking = false;
            }
        }
    }

    void AddMaxAngle()
    {
        currentForce += AddedForce;
    }
}
