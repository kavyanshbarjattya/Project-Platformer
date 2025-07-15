using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] float _bulletSpeed;
    [SerializeField] int damage;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += new Vector3(_bulletSpeed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
