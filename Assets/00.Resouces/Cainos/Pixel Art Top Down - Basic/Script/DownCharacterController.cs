using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace Cainos.PixelArtTopDown_Basic
{
    public class DownCharacterController : MonoBehaviour
    {
        public string currentMapName;

        public int hp = 100;
        public float speed;

        private Animator animator;

        private bool isDead;

        private void Start()
        {
            speed = 20f;

            animator = GetComponent<Animator>();
            isDead = false;

            if (hp == 0)
            {
                isDead = true;

                if (hp == 0 && isDead)
                {
                    GameOver();
                }
            }
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;

        }

        private void GameOver()
        {
            Debug.Log("당신은 죽었습니다");
        }
    }
}
