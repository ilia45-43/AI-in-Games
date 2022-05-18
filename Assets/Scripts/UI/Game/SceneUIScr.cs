using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUIScr : MonoBehaviour
{
    public GameObject canvasGameOver;

    public void GameOver()
    {
        canvasGameOver.SetActive(true);
        Time.timeScale = 0f;
        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = true;
    }

    public void PlayAgain()
    {
        canvasGameOver.SetActive(false);
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = false;
    }

    public void QuitToMenu()
    {
        canvasGameOver.SetActive(false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
