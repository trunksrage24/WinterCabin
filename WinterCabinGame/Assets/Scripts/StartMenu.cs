using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public void Continue()
    {
        LoadingSceneManager.Instance.LoadScene("Blocking_updated_sem_colliders");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
