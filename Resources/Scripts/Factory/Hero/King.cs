using UnityEngine;

public class King : MonoBehaviour, IHero
{
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Defense { get; set; }
    public float Speed { get; set; }
    public float DSpeed { get; set; }
    public int Range { get; set; }

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(gameObject.transform.position, Range, LayerMask.GetMask("Enemy"));
        if (hitEnemies != null)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.tag.Equals("Enemy"))
                {
                    Debug.Log("hit Enemy");
                }
            }
        }
        else
        {
            Debug.Log("null");
        }
    }
}
