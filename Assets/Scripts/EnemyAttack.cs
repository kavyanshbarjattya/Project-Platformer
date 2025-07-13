using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float _kickBack;
    [SerializeField] Rigidbody2D _playerRb;
    [SerializeField] Transform _playerTrans;
    [SerializeField] int _damage;

    PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = FindAnyObjectByType<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KickBack();
            int _remainingHealth = _playerHealth.TakeDamage(_damage);
            if (_remainingHealth < 0)
            {
                Destroy(collision.gameObject);
            }
            print("Player's Health is " + _remainingHealth);
        }
    }

    void KickBack()
    {
        Vector3 direction = (transform.position - _playerTrans.position).normalized;
        _playerRb.AddForce(-direction * _kickBack, ForceMode2D.Impulse);
    }
}
