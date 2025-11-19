using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
   public void StartButton(string sceneName)
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitButton()
    {
        Debug.Log("Quit the game!");
        Application.Quit();
    }

    public void CreditButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ReturnButton()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
