using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterSizeDown : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float sizeChangeSpeed = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("collider2D");
            StartCoroutine(DecreaseSizeOverTime());
        }
    }

    private IEnumerator DecreaseSizeOverTime()
    {
        while (player.localScale.x > 0.1f && player.localScale.y > 0.1f )
        {
            float newSize = Mathf.Clamp(player.localScale.x - sizeChangeSpeed * Time.deltaTime, 0.5f, 10f);
            player.localScale = new Vector2(newSize, newSize);
            Debug.Log("작아진다");

            if(newSize <= 0.5f)
            {
                yield break;
            }

            yield return null;
        }
    }
}
