using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    IEnumerator WaitCoroutine(int sceneIndex)
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(sceneIndex);
    }
    public void LoadByIndex(int sceneIndex)
    {
        StartCoroutine(WaitCoroutine(sceneIndex));
    }
}
