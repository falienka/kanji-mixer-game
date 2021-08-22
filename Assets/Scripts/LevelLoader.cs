using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string levelToLoad;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N) && GameManager.Inst.finishLevel)
        {
            LoadLevel();
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
