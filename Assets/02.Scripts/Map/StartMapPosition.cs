using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StartMapPosition : MonoBehaviour
{
    public string startPos;
    private TopDownCharacterController player;
    private CameraFollow camera;

    private void Awake()
    {
        player = FindObjectOfType<TopDownCharacterController>();
        camera = FindObjectOfType<CameraFollow>();
    }

    private void Start()
    {
        if (startPos == player.currentMapName)
        { 
            camera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            player.transform.position = transform.position;
        }
    }
}
