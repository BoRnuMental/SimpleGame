using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerHealth.onPlayerDied += ReloadScene;
    }
    private void OnDisable()
    {
        PlayerHealth.onPlayerDied -= ReloadScene;
    }
    private void ReloadScene()
    {
        StartCoroutine(ReloadSceneCoroutine());
    }
    IEnumerator ReloadSceneCoroutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
