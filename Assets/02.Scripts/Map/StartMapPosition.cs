using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StartMapPosition : MonoBehaviour
{
    public string startPos;
    private PlayerInputController player;
    private CameraFollow maincamera;

    private void Awake()
    {
        player = FindObjectOfType<PlayerInputController>();
        maincamera = FindObjectOfType<CameraFollow>();
    }

    private void Start()
    {
        if (startPos == player.currentMapName)
        {
            maincamera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            player.transform.position = transform.position;
        }
    }
}
