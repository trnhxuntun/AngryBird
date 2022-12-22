using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float defend;
    public GameObject effect;
    public AudioClip music;
    public AudioSource aus;
    public AudioClip destroysound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude > defend)
        {
            Destroy(gameObject,0.1f);
            Instantiate(effect, transform.position, Quaternion.identity);
            if (aus && destroysound)
            {
                aus.PlayOneShot(destroysound);
            }

        }    
        else
        {
            defend -= collision.relativeVelocity.magnitude;
        }    
    }
}
