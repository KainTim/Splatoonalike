using System;
using System.Collections;
using EnemyScripts;
using UnityEngine;

namespace WeaponScripts
{
  public class Ammo : MonoBehaviour
  {
    public int Damage = 5;
    private void OnTriggerEnter(Collider other)
    {
      HandleEnemyCollision(other);
    }

    private bool HandleEnemyCollision(Collider other)
    {
      var enemy = other.gameObject.GetComponent<Enemy>();
      if (enemy is null) return false;
      enemy.TakeDamage(Damage, this);
      StartCoroutine(Destroy());
      var particles = GetComponent<ParticleSystem>();
      particles.Play();
      return true;
    }

    private IEnumerator Destroy()
    {
      yield return new WaitForSeconds(0.4f) ;
      Destroy(gameObject);
    }
  }
}