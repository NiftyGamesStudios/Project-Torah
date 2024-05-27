using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelIncreament : MonoBehaviour
{
    public void IncreamentUnlock()
    {
        // LevelUnlocker.instance.CompleteLevel();
        PlayerPrefs.SetInt("LevelToUnlock", SceneManager.GetActiveScene().buildIndex+1);
    }
}
