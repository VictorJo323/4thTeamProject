using Cainos.PixelArtTopDown_Basic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private static MapManager _instance;

    public static MapManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject map = new GameObject("MapManager");
                map.AddComponent<MapManager>();
                _instance = map.GetComponent<MapManager>();
                DontDestroyOnLoad(map);
            }
            return _instance;
        }
        set
        {
            if (_instance == null) _instance = value;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (_instance != this) Destroy(this);
        }
    }
}
