using System.Collections;
using UnityEngine;
using WeaponScripts;

namespace EnemyScripts
{
  public class Enemy : MonoBehaviour
  {
    public float Health = 100;

    public void TakeDamage(int damage, Ammo ammo)
    {
      Health -= damage;
      if (!(Health <= 0))
        return;
      var newAmmo = Instantiate(ammo, transform.position, transform.rotation);
      newAmmo.Damage = 0;
      var scale = newAmmo.transform.localScale;
      scale.x *= 2;
      scale.z *= 2;
      newAmmo.transform.localScale = scale;
      Destroy(gameObject);
    }
  }
}