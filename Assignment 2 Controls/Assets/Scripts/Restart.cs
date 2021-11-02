using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    
    public void RestartGame()
    {
        SceneManager.LoadScene("Level01");
    }

    private static void LoadScene(string v)
    {
        throw new NotImplementedException();
    }
}
