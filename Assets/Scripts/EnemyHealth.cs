using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health;
    [SerializeField] int _damage;


    int _currentHealth;


    private void Start()
    {
        _currentHealth = _health;
        print(gameObject.name + "'s " + " Total Health: " + _health);
    }


    public int TakeDamage(int damage)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damage;
            print(gameObject.name + "'s " + " Current Health: " + _currentHealth);
        }
        return _currentHealth;
    }
}
