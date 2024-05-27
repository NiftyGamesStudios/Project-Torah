using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    public Button[] levelButtons; // Array of level buttons
    public int levelsToUnlock = 1; // Number of levels to unlock initially
    public static LevelUnlocker instance;
    private int unlockedLevels = 0; // Number of levels currently unlocked


    private void Awake()
    {
       
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("LevelToUnlock"))
        {
            levelsToUnlock = PlayerPrefs.GetInt("LevelToUnlock");
        }
        else
            PlayerPrefs.SetInt("LevelToUnlock", levelsToUnlock);

        UnlockLevels(levelsToUnlock); // Unlock initial levels
    }

    public void UnlockLevels(int levels)
    {
        unlockedLevels += levels;
        UpdateLevelButtons();
    }

    public void CompleteLevel()
    {
        unlockedLevels++;
        UpdateLevelButtons();
    }

    private void UpdateLevelButtons()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = (i < unlockedLevels);
        }
    }
}
