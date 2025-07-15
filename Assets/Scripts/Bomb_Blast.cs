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

    [SerializeField] BombSpawner _bombSpawner;
    [SerializeField] Game_Wining _gameWinning;

    [SerializeField] AudioSource _audioSource;
    private void OnEnable()
    {
        _bombSpawner = FindAnyObjectByType<BombSpawner>();
        _gameWinning = FindAnyObjectByType<Game_Wining>();
        StartCoroutine(TimerForBlast());
        _audioSource = GetComponent<AudioSource>();
    }


    IEnumerator TimerForBlast()
    {
        yield return new WaitForSeconds(_delay);
        BombDamage();
    }

    void BombDamage()
    {
        _audioSource.Play();

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
                        _gameWinning.levelInfo[_gameWinning._currentLevel]._total_enemies--;

                    }
                }/*
                    PlayerHealth _ph = c.GetComponent<PlayerHealth>();
                if (_ph != null)
                {

                    int _remainingPH = _ph.TakeDamage(_damage);
                    if (_remainingPH <= 0)
                    {
                        Time.timeScale = 0;

                    }
                }*/
            }

        }
        Destroy(gameObject);
        _bombSpawner._currentLimit++;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _blastRadius);
    }
}
