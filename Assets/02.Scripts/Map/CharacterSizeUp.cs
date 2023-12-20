using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSizeUp : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Camera mainCamera;

    private TopDownCharacterController controller;
    private CharacterStats characterStats;

    private bool sizeUpTrigger = false;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!sizeUpTrigger && collision.CompareTag("Player"))
        {
            controller = collision.GetComponent<TopDownCharacterController>();
            CameraSizeUp();
            PlayerSizeUp();
            sizeUpTrigger = true;
        }
    }

    private void PlayerSizeUp()
    {
        float newSize = 9.5f;

        if (controller != null)
        {
            player.transform.localScale = new Vector2(newSize, newSize);

            characterStats.spd = 2.9f;
            Debug.Log("커진다");
            sizeUpTrigger = false;
        }
    }

    private void CameraSizeUp()
    {
        float newSize = 20f;
        Debug.Log("카메라 없나본데");

        if (mainCamera != null)
        {
            Debug.Log("카메라 커진다");
            mainCamera.orthographicSize = newSize;
        }
    }
}
