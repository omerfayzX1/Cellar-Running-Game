using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int totalPapers = 5;
    private int collectedPapers = 0;

    public GameObject winTextObject;
    public Text paperCountText; // Sol �st k��e i�in Text

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
}
