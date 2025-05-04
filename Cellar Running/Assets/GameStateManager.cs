using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public RectTransform panel;

    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;

    private void Awake()
    {
        panel.gameObject.SetActive(false);
    }

    public void OnPlayerWon()
    {
        ShowPanel();
        loseText.gameObject.SetActive(false);
        winText.gameObject.SetActive(true);
    }

    public void OnPlayerLose()
    {
        ShowPanel();
        loseText.gameObject.SetActive(true);
        winText.gameObject.SetActive(false);  
    }

    private void ShowPanel()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        panel.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        panel.gameObject.SetActive(false);
        loseText.gameObject.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
