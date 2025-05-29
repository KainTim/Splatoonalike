using UnityEngine;
using UnityEngine.Serialization;

public class DelayedDestroy : MonoBehaviour
{
  public float DestroyDelay = 120f; 

  public void Start()
  {
    Destroy(gameObject, DestroyDelay);
  }
}