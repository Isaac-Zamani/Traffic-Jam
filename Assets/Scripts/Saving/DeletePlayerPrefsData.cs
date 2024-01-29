using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class DeletePlayerPrefsData
{
#if UNITY_EDITOR

    #region Public Methods

    [MenuItem("Saves/Delete PlayerPrefs Data")]
    public static void DeleteData()
    {
        bool userConfirmed = EditorUtility.DisplayDialog("Delete PlayerPrefs Data", "Are you sure you want to delete all player data? This action is irreversible.", "Yes", "No");

        if (userConfirmed)
        {
            PlayerPrefs.DeleteAll();

            PlayerPrefs.Save();

            Debug.Log("PlayerPrefs data deleted successfully.");

        }
    }

    #endregion

#endif
}
