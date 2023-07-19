using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
