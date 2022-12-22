using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public Vector3 CurrentPosition;

    public LineRenderer[] lineRenderer;

    public Transform[] stripposition;

    public Transform center;

    public Transform IdlePositions;

    bool ismousedown;

    public float maxlength;

    public float bottomBoundary;

    public GameObject birdPrefab;

    Rigidbody2D bird;

    Collider2D birdcollider;

    public float birdPositionoffset;

    public float force;
    public GameManager manager;
    public AudioSource keo;
    public AudioSource ban;
    public AudioClip tiengban;
    public int life;
    void Start()
    {
        lineRenderer[0].positionCount = 2;
        lineRenderer[1].positionCount = 2;
        lineRenderer[0].SetPosition(0, stripposition[0].position);
        lineRenderer[1].SetPosition(0, stripposition[1].position);
        life = 3;
        createbird();    
    }
    private void OnMouseDrag()
    {
            
    }
    void createbird()
    {
        bird = Instantiate(birdPrefab).GetComponent<Rigidbody2D>();
        birdcollider = bird.GetComponent<Collider2D>();
        birdcollider.enabled = false;
        manager.bird++;
        bird.isKinematic=true;
        resetstrip();
    }
    void Update()
    {
        if(life>0)
        {
            if (ismousedown == true)
            {

                Vector3 MousePosition = Input.mousePosition;
                MousePosition.z = 10;
                CurrentPosition = Camera.main.ScreenToWorldPoint(MousePosition);
                CurrentPosition = center.position + Vector3.ClampMagnitude(CurrentPosition - center.position, maxlength);
                CurrentPosition = ClamBoundary(CurrentPosition);
                Setstrips(CurrentPosition);
                if (birdcollider)
                {
                    birdcollider.enabled = true;
                }
            }
            else
            {
                resetstrip();
            }
        }
        
          
    }
    private void OnMouseDown()
    {
        ismousedown = true;
        keo.Play();     
    }
    private void OnMouseUp()
    {
        ismousedown=false;
        Shoot();
        life--;
        keo.Stop();
    }
    void Shoot()
    {
        bird.isKinematic = false;
        Vector3 birdforce = (CurrentPosition - center.position) * force * -1;
        bird.velocity= birdforce;
        bird = null;
        birdcollider = null;
        ban.PlayOneShot(tiengban);
        Invoke("createbird", 2);
    }
    void resetstrip()
    {
        CurrentPosition = IdlePositions.position;
        Setstrips(CurrentPosition);
    }   
    void Setstrips(Vector3 position)
    {
        lineRenderer[0].SetPosition(1, position);
        lineRenderer[1].SetPosition(1, position);
        if(bird)
        {
            Vector3 dir = position - center.position;
            bird.transform.position = position + dir.normalized * birdPositionoffset;
            bird.transform.right = -dir.normalized;
        }
        
    }    
    Vector3 ClamBoundary(Vector3 vector)
    {
        vector.y = Mathf.Clamp(vector.y, bottomBoundary, 1000);
        return vector;
    }
}
