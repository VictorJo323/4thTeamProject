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
        //���ӸŴ����� ���ٸ� ���� ������Ʈ�� ���ӸŴ�����
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        //���ӸŴ����� 2���̻� ��ũ��Ʈ�� �� ������ ���߿� �������� ������Ʈ �ı�
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
