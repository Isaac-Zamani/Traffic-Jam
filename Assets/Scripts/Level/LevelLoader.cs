
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private LevelList levelList;

    private int _currentLevel;
    
    private void Start()
    {
        _currentLevel = LevelSaver.GetCurrentLevel();

        LoadCurrentLevel(_currentLevel);

    }

    private void LoadCurrentLevel(int currentLevel)
    {
        Instantiate(levelList.levelList[currentLevel]);
    }

    public void UpdateNextLevel()
    {
        if (_currentLevel < levelList.levelList.Count - 1)
        {
            _currentLevel++;
            LevelSaver.SaveCurrentLevel(_currentLevel);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
