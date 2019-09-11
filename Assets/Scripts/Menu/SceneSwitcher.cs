using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}