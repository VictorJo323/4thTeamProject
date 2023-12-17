using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public Transform Player { get; private set; }
    [SerializeField] private string playerTag = "Player";

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
                _instance = go.GetComponent<GameManager>();
                DontDestroyOnLoad(go);
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
        //게임매니저가 없다면 현재 오브젝트를 게임매니저로
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        //게임매니저가 2개이상 스크립트로 들어가 있을시 나중에 지정받은 오브젝트 파괴
        else
        {
            if (_instance != this) Destroy(this);
        }
        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
