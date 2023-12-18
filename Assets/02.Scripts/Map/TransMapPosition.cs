using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransMapPosition : MonoBehaviour
{
    public string mapName;
    private TopDownCharacterController player;
    private CameraFollow camera;

    [SerializeField] private Transform target;

    private void Awake()
    {
        player = FindObjectOfType<TopDownCharacterController>();
        camera = FindObjectOfType<CameraFollow>();

        if (player == null)
        {
            Debug.Log("�÷��̾ ã�� �� ����");
        }

        if (camera == null)
        {
            Debug.Log("ī�޶� ã�� �� ����");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            player.currentMapName = mapName;
            camera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            player.transform.position = target.transform.position;
        }
    }
}