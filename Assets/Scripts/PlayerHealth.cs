using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _health;


    int _currentHealth;


    private void Start()
    {
        _currentHealth = _health;
    }


    public int TakeDamage(int damage)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damage;
        }
        Debug.Log(gameObject.name + "'s health: " + _currentHealth);
        return _currentHealth;
    }
}
