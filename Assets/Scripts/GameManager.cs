using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Canvas WinUI;
    public Canvas LostUI;
    public float Score;
    public int piginmap;
    public AudioClip thang;
    public AudioClip thua;
    public AudioSource levelcomplete;
    public int pig;
    public int bird;
    public Text diem;
    public Text life;
    public GameObject video;
    public int i = 0;
    void Start()
    {
        
        Invoke("videoman", 16f);
    }
    public void videoman()
    {
        video.gameObject.SetActive(false);
    }    
    public void lostui()
    {
        LostUI.gameObject.SetActive(true);
        
    }
    public void winui()
    {
        if(i== 1)
        {
            Debug.Log("ch?y m�n h�nh th?ng");
            video.gameObject.SetActive(false);
            WinUI.gameObject.SetActive(true);
            LostUI.gameObject.SetActive(false);
            levelcomplete.PlayOneShot(thang);
            i++;
        }    
        
    }
    void Update()
    {
        if (pig == piginmap && bird >= 3 || pig == piginmap && bird < 3)
        {
            if(pig==4)
            {
                if(i==0)
                {
                    video.gameObject.SetActive(true);
                    i++;
                    Debug.Log("ch?y video th?ng");
                }                   
                Invoke("winui", 12f);
            }   
            else
            {
                winui();
            }    
            
            
        }    
            
        diem.text = Score.ToString();
        if(bird > 3 && pig < piginmap)
        {
            
            lostui();
            levelcomplete.PlayOneShot(thua);
            Debug.Log("Thua man choi");
        }
        if(bird <=3)
        life.text = Convert.ToString(3-bird);
    }
}
