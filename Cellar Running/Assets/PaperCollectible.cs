using UnityEngine;

public class PaperCollectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.CollectPaper();
            Destroy(gameObject);
        }
    }
}
