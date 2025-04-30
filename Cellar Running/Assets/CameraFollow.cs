using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Oyuncu
    public Vector3 offset;    // Kameran�n pozisyon fark�

    void LateUpdate()
    {
        transform.position = player.position + offset;  // Kameray� oyuncunun pozisyonuyla hizala
    }
}
