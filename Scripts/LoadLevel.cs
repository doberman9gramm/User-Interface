using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void PreviousLevel()
    {
        SceneManager.LoadScene(0);
    }
}
