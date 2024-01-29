using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelSaver
{
    private const string LevelNumber = "LevelNumber";
    
    public static void SaveCurrentLevel(int currentLevelNumber) => PlayerPrefs.SetInt(LevelNumber, currentLevelNumber );

    public static int GetCurrentLevel() => PlayerPrefs.GetInt(LevelNumber, 0);
}
