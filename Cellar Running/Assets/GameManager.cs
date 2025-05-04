using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int totalPapers;
    private int collectedPapers = 0;

    public TextMeshProUGUI paperCountText; // Sol üst köþe için Text


    public static GameManager instance;
    public GameStateManager stateManager { get; private set; }

    private void Awake()
    {
        // Eðer instance zaten varsa, bu objeyi yok et
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Bu objenin sahneler arasýnda yok olmasýný engeller
        }

        stateManager = gameObject.GetComponent<GameStateManager>();
        totalPapers = FindObjectsByType<PaperCollectible>(FindObjectsSortMode.None).Length;
    }
    void Start()
    {
        UpdatePaperCountText();
    }

    public void CollectPaper()
    {
        collectedPapers++;
        UpdatePaperCountText();

        if (collectedPapers >= totalPapers)
        {
            stateManager.OnPlayerWon();
        }
    }


    void UpdatePaperCountText()
    {
        paperCountText.text = "Kaðýtlar: " + collectedPapers + " / " + totalPapers;
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
