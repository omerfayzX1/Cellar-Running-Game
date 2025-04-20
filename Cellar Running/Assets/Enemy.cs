using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform pointA; // Devriye noktasýnýn A
    public Transform pointB; // Devriye noktasýnýn B
    public float moveSpeed = 3f; // Normal hýz
    public float chaseSpeed = 5f; // Takip hýzý
    public float detectionRange = 10f; // Düþman, bu mesafeden sonra oyuncuyu fark eder



    private Transform currentTarget;
    private Transform player;
    private bool isChasing = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncuyu bul
        currentTarget = pointA; // Ýlk hedef nokta PointA
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Eðer oyuncu yakýnsa, düþman onu takip etmeye baþlasýn
        if (distanceToPlayer < detectionRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            // Oyuncuyu takip et
            ChasePlayer();
        }
        else
        {
            // Devriye yap
            Patrol();
        }
    }

    void Patrol()
    {
        // Hedefe doðru hareket et
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);

        // Eðer hedefe ulaþtýysa, yeni hedefe yönel
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.2f)
        {
            if (currentTarget == pointA)
                currentTarget = pointB; // Hedef A'dan B'ye geç
            else
                currentTarget = pointA; // Hedef B'den A'ya geç
        }
    }

    void ChasePlayer()
    {
        // Oyuncuya doðru hareket et
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }
}
