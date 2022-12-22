using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
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
    void Start()
    {
        
    }
    public void lostui()
    {
        LostUI.gameObject.SetActive(true);
        
    }
    public void winui()
    {
        WinUI.gameObject.SetActive(true);
        
    }
    void Update()
    {
        if (pig == piginmap && bird > 3 || pig == piginmap && bird < 3)
        {
            winui();
            LostUI.gameObject.SetActive(false);
            levelcomplete.PlayOneShot(thang);
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
