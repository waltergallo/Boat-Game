using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int gameMode = 0;
    public bool timeRunning = false;
    public float time;
    public int min;
    public float secs;
    public TextMeshProUGUI timer;
    public GameObject boosts;


    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (timeRunning == true)
        {

            time += Time.deltaTime;
            min = (int)time;
            secs = time % 60;

            timer.text = "Time Elapsed: " + min/60 + "." + secs.ToString("0.00");

        }

    }

    public void Standby()
    {

        gameMode = 0;

    }

    public void Phantom()
    {

        gameMode = 1;

    }

    public void Thrasher()
    {

        gameMode = 2;

    }

    public void Riptide()
    {

        gameMode = 3;

    }

    public void ZeraTimerRapaz()
    {

        timeRunning = true;
        time = 0;

    }

    public void BoostInstantiation()
    {

        Destroy(GameObject.Find("Boost bottles"));
        Destroy(GameObject.Find("Boost bottles(Clone)"));
        Instantiate(boosts);

    }
}