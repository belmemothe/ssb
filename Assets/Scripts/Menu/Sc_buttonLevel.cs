using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sc_buttonLevel : MonoBehaviour
{
    /* Pour plus tards
    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void GotoSampleLevel()
    {
        //StartCoroutine(LoadYourAsyncScene());
        SceneManager.LoadScene("SampleScene");
    }

}
