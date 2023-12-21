using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject endGame;
    private PlayerInputController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerInputController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Time.timeScale = 0.0f;
            SceneManager.LoadScene("TobeContine");
        }
    }
}
