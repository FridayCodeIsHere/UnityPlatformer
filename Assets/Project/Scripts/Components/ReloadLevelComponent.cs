using UnityEngine.SceneManagement;
using UnityEngine;

public class ReloadLevelComponent : MonoBehaviour
{
    public void ReloadLevel()
    {
        string nameLevel = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nameLevel);
    }
}
