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
        Debug.Log("Ka��t al�nd�! " + collectedPages + "/" + totalPages);

        if (collectedPages >= totalPages)
        {
            WinGame();
        }
    }

    public void RestartGame()
    {
        Debug.Log("Yakaland�n! Oyun yeniden ba�l�yor...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void WinGame()
    {
        Debug.Log("Tebrikler! T�m ka��tlar� toplad�n ve oyunu kazand�n!");
        // Buraya kazanma ekran�, ses veya sahne ge�i�i ekleyebilirsin
    }
}
