using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILevelCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        int currentLevel = LevelSaver.GetCurrentLevel() + 1;

        text.text = currentLevel.ToString();
    }
}
