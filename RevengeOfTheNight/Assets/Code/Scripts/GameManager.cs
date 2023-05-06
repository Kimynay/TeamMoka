using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    private int playerPosition = 2;
    private int humanPosition = 8;
    public float nightDuration = 60;

    public GameObject moonAnchor;
    private float moonStartRotation = 29f;

    private void Update()
    {
        if(Time.time < nightDuration)
            moonAnchor.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(moonStartRotation, -moonStartRotation, Time.time/ nightDuration));
        else
            SceneManager.LoadScene(3);

    }
    public void setHumanPosition(int pos)
    {
        humanPosition = pos;
        if (humanPosition==playerPosition)
        {
             SceneManager.LoadScene(3);
        }
    }
    public void setPlayerPosition(int pos)
    {
        playerPosition=pos;
        if (humanPosition==playerPosition)
        {
             SceneManager.LoadScene(3);
        }
    }

    
}
