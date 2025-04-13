using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.instance.RestartGame();
        }
    }


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0f, v);
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }
}
