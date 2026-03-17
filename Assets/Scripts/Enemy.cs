using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform enemyPos;
    [SerializeField] private int health = 50;
    [SerializeField] private GameObject dieVFX;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{name}: took {damage} damage");

        if ( health <= 0 )
        {
            var dieVFx = Instantiate(dieVFX, enemyPos.position, Quaternion.identity);
            Destroy(gameObject, 0.5f);
            Destroy(dieVFx, 1.0f);
        }
    }
}
