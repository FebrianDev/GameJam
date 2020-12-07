using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuCanvas : MonoBehaviour
{
    public GameObject panel;
    private void Start()
    {
        panel.SetActive(false);
    }
    private void Update()
    {
        if (PlayerMove.isGameOver)
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
        }

    }

    public void Restart()
    {
        Time.timeScale = 1f;
        PlayerMove.isGameOver = false;
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
