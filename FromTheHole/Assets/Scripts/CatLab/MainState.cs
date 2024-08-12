using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainState : MonoBehaviour
{
    public string enteredPortal = null;
    public GameObject[] cameras;
    public void enterPortal()
    {
        if (enteredPortal != null)
        {
            StartCoroutine(LoadScene(enteredPortal));
        }
    }
    void Start()
    {
        Debug.Log("1. 마우스 클릭으로 캐릭터 이동 가능");
        Debug.Log("2. Z, X 혹은 마우스 휠로 카메라 줌 가능");
        Debug.Log("3. SpaceBar로 상호작용 가능 (게임 진입 포함)");
    }
    IEnumerator LoadScene(string sceneName, int delay = 3)
    {
        Debug.Log($"3초 후 로드!");
        yield return new WaitForSeconds(1);
        Debug.Log($"2초 후 로드!");
        yield return new WaitForSeconds(1);
        Debug.Log($"1초 후 로드!");
        yield return new WaitForSeconds(1);
        Debug.Log($"\"{sceneName}\"씬 으로 이동!");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }

    public void CameraSwitch(string name)
    {
        foreach (GameObject camera in cameras)
        {
            if (camera.name == name) camera.SetActive(true);
            else camera.SetActive(false);
        }
    }
}
