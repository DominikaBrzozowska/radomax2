using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneNavigateButton : MonoBehaviour
{
    public string sceneName;

    private void LoadScene()
    {
        Debug.Log("GameObject clicked: " + gameObject.name + ", loading scene: " + sceneName);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    void OnMouseDown()
    {
        LoadScene();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            LoadScene();
        }
    }
}
