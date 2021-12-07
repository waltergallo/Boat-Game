using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gameMode = 0;

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {



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
}