using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MapTrap : MonoBehaviour
{
    private DownCharacterController player;
    [SerializeField] private GameObject character;

    private void Start()
    {
        player = FindObjectOfType<DownCharacterController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player.hp = 0;
            Destroy(character);
        }
    }
}
