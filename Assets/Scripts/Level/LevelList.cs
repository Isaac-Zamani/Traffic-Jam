using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level List", menuName = "Level/New Level List")]
public class LevelList : ScriptableObject
{
    public List<GameObject> levelList;
}
