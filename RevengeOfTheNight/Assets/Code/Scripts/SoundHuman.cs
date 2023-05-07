using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHuman : MonoBehaviour
{
    private AudioSource audioSource;
    public List<AudioClip> footSteps;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WalkSound()
    {
        int rand = Random.Range(0, footSteps.Count);
        audioSource.PlayOneShot(footSteps[rand]);
    }
}
