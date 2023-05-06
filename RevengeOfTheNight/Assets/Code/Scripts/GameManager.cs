using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    private int playerPosition = 2;
    private int humanPosition = 8;
    
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
