using UnityEngine;

public class PaperCollectible : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        if (gm == null)
            Debug.LogError("GameManager bulunamadý! Collectible çalýþmýyor.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gm.CollectPaper();
            Destroy(gameObject);
        }
    }
}
