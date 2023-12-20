using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartBtn : MonoBehaviour
{
    public void GameStart()
    {
        //TODO 공백 부분에 씬이름 적어주세요.
        SceneManager.LoadScene("");
    }
}
