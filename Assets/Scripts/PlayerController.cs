using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float[] posx;
    [SerializeField] private bool isHit;
    [SerializeField] private bool isRight;

    private bool isRotating = false;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x,
            transform.position.y,
            transform.position.z
        ));

        HandleRotation();

        if (Input.GetMouseButtonDown(0) && isHit && mousePos.x >= posx[0] && mousePos.x <= posx[1])
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            Flip();
            isHit = false;
            if (!isHit)
            {
                moveSpeed *= -1;
            }
        }
    }

    private void HandleRotation()
    {
        if (!isRotating) return;

        float step = 15f * Time.deltaTime;
        Quaternion targetRotation = Quaternion.Euler(0, isRight ? 0 : 180f, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, step);

        if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
        {
            isRotating = false;
        }
    }

    private void Flip()
    {
        isRight = !isRight;
        isRotating = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            isHit = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Score"))
        {
            gameManager.score++;
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }
    }
}