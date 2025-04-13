using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            GameManager.instance.CollectPage();
            Destroy(gameObject);
        }



        if (other.CompareTag("Player"))
        {
            GameManager.instance.CollectPage();
            Destroy(gameObject);
        }

    }

}

