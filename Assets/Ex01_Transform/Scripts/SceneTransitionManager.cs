using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public int sceneIndex = 0;
    public void LoadScene(int sceneID)
    {
        //현재 씬에서 원하는 다른 씬으로 씬을 로드하는 함수.
        SceneManager.LoadScene(sceneID);
    }

    //영역 안에 들어오면 호출되는 콜백함수
    private void OnTriggerEnter(Collider other)
    {
        LoadScene(sceneIndex);
    }
}
