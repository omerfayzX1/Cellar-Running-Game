using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform pointA; // Devriye noktas�n�n A
    public Transform pointB; // Devriye noktas�n�n B
    public float moveSpeed = 3f; // Normal h�z
    public float chaseSpeed = 5f; // Takip h�z�
    public float detectionRange = 10f; // D��man, bu mesafeden sonra oyuncuyu fark eder



    private Transform currentTarget;
    private Transform player;
    private bool isChasing = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncuyu bul
        currentTarget = pointA; // �lk hedef nokta PointA
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // E�er oyuncu yak�nsa, d��man onu takip etmeye ba�las�n
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
        // Hedefe do�ru hareket et
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);

        // E�er hedefe ula�t�ysa, yeni hedefe y�nel
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.2f)
        {
            if (currentTarget == pointA)
                currentTarget = pointB; // Hedef A'dan B'ye ge�
            else
                currentTarget = pointA; // Hedef B'den A'ya ge�
        }
    }

    void ChasePlayer()
    {
        // Oyuncuya do�ru hareket et
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }
}
