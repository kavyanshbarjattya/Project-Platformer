using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Bomb_Blast : MonoBehaviour
{
    [Tooltip("Delay for bomb to be blast")]
    [SerializeField] float _delay;

    [Tooltip("How much area can bomb affect")]
    [SerializeField] float _blastRadius;

    [SerializeField] LayerMask _canDamageLayer;
    [SerializeField] int _damage;

    private void OnEnable()
    {
        StartCoroutine(TimerForBlast());
    }


    IEnumerator TimerForBlast()
    {
        yield return new WaitForSeconds(_delay);
        BombDamage();
    }

    void BombDamage()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, _blastRadius , _canDamageLayer);
        foreach (Collider2D c in col)
        {
            if (c != null)
            {

                EnemyHealth enemyHealth = c.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    int _remainingHealth = enemyHealth.TakeDamage(_damage);
                    if (_remainingHealth <= 0)
                    {
                        Destroy(c.gameObject);

                    }
                }
                    PlayerHealth _ph = c.GetComponent<PlayerHealth>();
                if (_ph != null)
                {

                    int _remainingPH = _ph.TakeDamage(_damage);
                    if (_remainingPH <= 0)
                    {
                        Destroy(c.gameObject);

                    }
                }
            }

        }
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _blastRadius);
    }
}
