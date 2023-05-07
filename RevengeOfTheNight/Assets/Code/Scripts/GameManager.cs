using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public int playerPosition = 1;
    public int humanPosition = 8;
    private float sameRoomTime = 1f;

    public float nightDuration = 60;
    public GameObject moonAnchor;
    private float moonStartRotation = 29f;
    public int destroyedObjects = 0;

    private void Update()
    {
        if (Time.time < nightDuration)
            moonAnchor.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(moonStartRotation, -moonStartRotation, Time.time / nightDuration));
        else
            SceneManager.LoadScene(3);

    }
    public void setHumanPosition(int pos)
    {
        humanPosition = pos;
        if (humanPosition==playerPosition)
        {
            Invoke("loseIfSameRoom",sameRoomTime);
        }
    }
    public void setPlayerPosition(int pos)
    {
        playerPosition=pos;
        if (humanPosition==playerPosition)
        {
            Invoke("loseIfSameRoom",sameRoomTime);
        }
    }

    private void loseIfSameRoom()
    {
        if (humanPosition==playerPosition)
        {
            SceneManager.LoadScene(3);
        }
    }
    
}
