using System.Collections;
using System.Collections.Generic;
using Meta.WitAi;
using UnityEngine;

public class Consumable : MonoBehaviour
{
  [SerializeField] GameObject portion;

private bool audioIsActive = false;

  public AudioSource audioSrc;
  public AudioClip munch;



  void Start() {
    audioSrc = GetComponent<AudioSource>();
  }

    [ContextMenu("Consume")]
  public void Consume() {
    audioSrc.PlayOneShot(munch);
    audioIsActive = true;
    
  }

  void Update() {
    if (audioIsActive) {
        if(!audioSrc.isPlaying) {
            portion.DestroySafely();
        }
    }
  }
}
