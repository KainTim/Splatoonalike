using System.Collections;
using UnityEngine;

namespace EnemyScripts
{
  public class Enemy : MonoBehaviour
  {
    public float Health = 100;

    public void TakeDamage(int damage)
    {
      Health -= damage;
      if (!(Health <= 0))
        return;
      Destroy(gameObject);
    }
  }
}