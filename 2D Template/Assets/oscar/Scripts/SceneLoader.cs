using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    
    
    
    public void loadCredits(string scenename)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scenename);
    }
    
    
}
