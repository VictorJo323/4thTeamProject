using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("AudioManager");
                go.AddComponent<AudioManager>();
                _instance = go.GetComponent<AudioManager>();
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
