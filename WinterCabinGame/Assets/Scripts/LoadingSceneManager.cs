using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen1;
    [SerializeField] private GameObject loadingScreen2;
    [SerializeField] private GameObject loadingScreen3;

    public static LoadingSceneManager Instance { get; private set; }
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(string scene, int loadingScreen = 1)
    {
        StartCoroutine(Load(scene, loadingScreen));
    }
    
    private IEnumerator Load (string scene, int loadingScreen)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        if (loadingScreen == 1)
            loadingScreen1.SetActive(true);
        else if (loadingScreen == 2)
            loadingScreen2.SetActive(true);
        else
            loadingScreen3.SetActive(true);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        if (loadingScreen == 1)
            loadingScreen1.SetActive(false);
        else if (loadingScreen == 2)
            loadingScreen2.SetActive(false);
        else
            loadingScreen3.SetActive(false);
    }

}
