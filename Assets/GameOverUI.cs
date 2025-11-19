using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene("Shu's scene");
    }
    public void Main_Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
