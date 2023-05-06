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
    public bool disapearWhenBreak = true;
    public bool throwPartWhenBraek = true;
    public bool changeImageWhenBreak = false;

    private bool broken = false;
    private bool haveFell = false;
    public BreakingType BreakingMode = 0;
    public enum BreakingType { Fall, Scratch, ScratchLoosePart}
    public List<GameObject> brokenParts;
    void Start()
    {
        image = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (BreakingMode == BreakingType.Fall)
        {
            if (isShaking)
            {
                Shake();
                localTime += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (BreakingMode == BreakingType.Fall)
        {
            if (other.CompareTag("Player"))
            {
                isShaking = true;
                AddMaxAngle();
                localTime = 0.0f;
            }
        }
    }

    void Shake()
    {
        if (BreakingMode == BreakingType.Fall)
        {
            if (!haveFell)
            {
                if (currentForce > 1.0f)
                {
                    Debug.Log("reee");
                    GetComponent<BoxCollider2D>().enabled = false;
                    Fall();
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
        }
    }

    void AddMaxAngle()
    {
        currentForce += AddedForce;
    }

    void Fall()
    {
        image.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        haveFell = true;
    }

    public void Break()
    {
        if (!broken)
        {
            if (disapearWhenBreak)
            {
                image.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }
            if (changeImageWhenBreak && image.transform.GetChild(1) != null)
            {
                image.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
            }
            if (throwPartWhenBraek)
            {
                for (int i = 0; i < brokenParts.Count; i++)
                {
                    GameObject part = Instantiate(brokenParts[i], image.transform.position + Vector3.up * 1f, Quaternion.identity);
                    float rand = Random.Range(-1f, 1f);
                    Vector2 dir = new Vector2(rand, 1f).normalized;
                    part.GetComponent<Rigidbody2D>().AddForce(dir * 3f, ForceMode2D.Impulse);
                }
                broken = true;
            }
        }
    }
}
