using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int collectedPages = 0;
    public int totalPages = 5;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void CollectPage()
    {
        collectedPages++;
        Debug.Log("Kaðýt alýndý! " + collectedPages + "/" + totalPages);

        if (collectedPages >= totalPages)
        {
            WinGame();
        }
    }

    public void RestartGame()
    {
        Debug.Log("Yakalandýn! Oyun yeniden baþlýyor...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void WinGame()
    {
        Debug.Log("Tebrikler! Tüm kaðýtlarý topladýn ve oyunu kazandýn!");
        // Buraya kazanma ekraný, ses veya sahne geçiþi ekleyebilirsin
    }
}
