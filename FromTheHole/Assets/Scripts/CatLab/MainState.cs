using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainState : MonoBehaviour
{
    public string enteredPortal = null;
    public void enterPortal()
    {
        if (enteredPortal != null)
        {
            StartCoroutine(LoadScene(enteredPortal));
        }
    }
    IEnumerator LoadScene(string sceneName, int delay = 3)
    {
        Debug.Log($"{delay}초 후 로드!");
        yield return new WaitForSeconds(delay);
        Debug.Log($"\"{sceneName}\"씬 으로 이동!");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}
