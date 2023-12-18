using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransMapPosition : MonoBehaviour
{
    public string mapName;
    private TopDownCharacterController player;
    private CameraFollow camera;

    [SerializeField] private Transform StagePos;
    [SerializeField] GameObject _trueMap;
    [SerializeField] GameObject _falseMap;

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
            _trueMap.SetActive(true);
            _falseMap.SetActive(false);

            player.currentMapName = mapName;
            camera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            player.transform.position = StagePos.transform.position;
        }
    }
}