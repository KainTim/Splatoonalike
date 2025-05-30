using System;
using UnityEngine;
using UnityEngine.Serialization;

public class DelayedDestroy : MonoBehaviour
{
  public float DestroyDelay = 45f;
  private float _startTime;

  public float MaxSizeDestroyDelay = 360f;

  public void Start()
  {
    _startTime = Time.time;
  }
  private void Update()
  {
    if (_startTime + DestroyDelay < Time.time)
    {
      Destroy(gameObject);
    }
  }
  public void ResetTimer()
  {
    _startTime = Time.time;
  }
}