using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Oyuncu
    public Vector3 offset;    // Kameranýn pozisyon farký

    void LateUpdate()
    {
        transform.position = player.position + offset;  // Kamerayý oyuncunun pozisyonuyla hizala
    }
}
