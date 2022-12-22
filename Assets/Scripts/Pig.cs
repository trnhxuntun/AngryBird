using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public GameManager GameManager;
    public float defend;
    public GameObject effect;
    public AudioSource aus;
    public AudioClip destroysound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > defend)
        {
            Destroy(gameObject, 0.1f);
            Instantiate(effect, transform.position, Quaternion.identity);
            GameManager.Score += 50;
            GameManager.pig++;
            if(aus && destroysound)
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
