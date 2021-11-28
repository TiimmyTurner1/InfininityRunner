using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.ApplyDamage(_damage);

            _audioSource.Play();
            gameObject.GetComponent<Renderer>().enabled = false;
            Invoke("Die", _audioSource.clip.length);
        }
        else if(collision.TryGetComponent<BoxCollider2D>(out BoxCollider2D boxCollider2D))
        {
            Die();
        }
        
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
