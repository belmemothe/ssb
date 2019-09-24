using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Niveau1 : MonoBehaviour
{
    IEnumerator LoadYourAsyncScene()
    {
        //AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Niveau Arthur");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(LoadYourAsyncScene());
        }
    }
}
