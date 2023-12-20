using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public Transform Player { get; private set; }
    [SerializeField] private string playerTag = "Player";
    private HealthSystem playerHealthSystem;




    [SerializeField] private int currentWaveIndex = 0;
    private int currentSpawnCount = 0;
    private int waveSpawnCount = 0;
    private int waveSpawnPosCount = 0;

    public float spawnInterval = .5f;
    public List<GameObject> enemyPrefebs = new List<GameObject>();

    [SerializeField] private Transform spawnPositionsRoot;
    private List<Transform> spawnPostions = new List<Transform>();

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

        playerHealthSystem = Player.GetComponent<HealthSystem>();
        playerHealthSystem.OnDeath += GameOver;



        for (int i = 0; i < spawnPositionsRoot.childCount; i++)
        {
            spawnPostions.Add(spawnPositionsRoot.GetChild(i));
        }


    }
    private void Start()
    {
        StartCoroutine("StartNextWave");
    }

    IEnumerator StartNextWave()
    {
        while (true)
        {
            Debug.Log(currentSpawnCount+"!");
            if(currentSpawnCount < 0 )
            {
                currentSpawnCount = 0;
            }
            if (currentSpawnCount == 0)
            {
                
                yield return new WaitForSeconds(2f);





                if (currentWaveIndex % 5 == 0)
                {
                    waveSpawnPosCount = waveSpawnPosCount + 1 > spawnPostions.Count ? waveSpawnPosCount : waveSpawnPosCount + 1;
                    waveSpawnCount = 0;
                }

                if (currentWaveIndex % 3 == 0)
                {
                    waveSpawnCount += 1;
                }


                for (int i = 0; i < waveSpawnPosCount; i++)
                {
                    int posIdx = Random.Range(0, spawnPostions.Count);
                    for (int j = 0; j < waveSpawnCount; j++)
                    {
                        int prefabIdx = Random.Range(0, enemyPrefebs.Count);
                        GameObject enemy = Instantiate(enemyPrefebs[prefabIdx], spawnPostions[posIdx].position, Quaternion.identity);
                        enemy.GetComponent<HealthSystem>().OnDeath += OnEnemyDeath;

                        currentSpawnCount++;
                        yield return new WaitForSeconds(spawnInterval);
                    }
                }

                currentWaveIndex++;
            }

            yield return null;
        }
    }



    private void OnEnemyDeath()
    {
        currentSpawnCount--;
    }


    private void GameOver()
    {
        SceneManager.LoadScene("04.GameOVer");

    }



    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }



}
