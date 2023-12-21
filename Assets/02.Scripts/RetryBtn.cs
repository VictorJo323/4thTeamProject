using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryBtn : MonoBehaviour
{
    public void Retry()
    {
        Time.timeScale = Time.deltaTime;
        SceneManager.LoadScene("Stage");
    }
}
