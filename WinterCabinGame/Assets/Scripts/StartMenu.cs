using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public void Continue()
    {
        LoadingSceneManager.Instance.LoadScene("GameScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
