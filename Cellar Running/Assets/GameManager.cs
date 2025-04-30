using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int totalPapers = 5;
    private int collectedPapers = 0;

    public GameObject winTextObject;
    public Text paperCountText; // Sol �st k��e i�in Text


    private static GameManager instance;

    private void Awake()
    {
        // E�er instance zaten varsa, bu objeyi yok et
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Bu objenin sahneler aras�nda yok olmas�n� engeller
        }
    }
    void Start()
    {
        winTextObject.SetActive(false);
        UpdatePaperCountText();
    }

    public void CollectPaper()
    {
        collectedPapers++;
        UpdatePaperCountText();

        if (collectedPapers >= totalPapers)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        winTextObject.SetActive(true);
    }

    void UpdatePaperCountText()
    {
        paperCountText.text = "Ka��tlar: " + collectedPapers + " / " + totalPapers;
    }

    void OnLevelWasLoaded(int level)
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
