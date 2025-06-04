using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float destroyY = 5.5f;

    void Update()
    {
        MoveUpwards();
        CheckOutOfBounds();
    }

    private void MoveUpwards()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    private void CheckOutOfBounds()
    {
        if (transform.position.y >= destroyY)
        {
            Destroy(gameObject);
        }
    }
}