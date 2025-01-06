using GameDevWithMarco.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.Player
{


    public class Player_Movement : MonoBehaviour
    {
        /// <summary>
        /// This script is dealing with the dash of the player
        /// </summary>

        private Rigidbody2D rb;
        public float dashSpeed;
        private float dashTime;
        public float startDashTime;
        public int direction;
        public Transform[] lerpPositionArray;
        private float lerpTime = 0.2f;
        private Vector3 newPosition;
        private int arrayNumber = 2;
        private bool isWaiting;
        private Animator anim;

        void Awake()
        {
            SetupVariables();
        }

        void Update()
        {
            Dash();
        }

        private void Clamper()
        {
            if (arrayNumber <= 0) { arrayNumber = 0; }
            if (arrayNumber >= 4) { arrayNumber = 4; }
        }

        private void SetupVariables()
        {
            transform.position = lerpPositionArray[2].transform.position;
            newPosition = transform.position;
            rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            anim = GetComponent<Animator>();
        }


        private void Dash()
        {
            if (direction == 0)
            {
                anim.SetBool("isDashing", false);
                if (!isWaiting)
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        StartCoroutine(MoveToNextPositionToTheRight());
                        direction = 2;
                        anim.SetBool("isDashing", true);
                        AudioManager.Instance.Dash();
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        StartCoroutine(MoveToNextPositionToTheLeft());
                        direction = 1;
                        anim.SetBool("isDashing", true);
                        AudioManager.Instance.Dash();
                    }
                }

            }
            else
            {
                if (dashTime <= 0)
                {
                    direction = 0;
                    dashTime = startDashTime;
                    rb.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;
                }
            }
        }



        private IEnumerator MoveToNextPositionToTheLeft()
        {
            isWaiting = true;
            float timePercentage = 0f;
            Vector3 startPos = transform.position;
            arrayNumber--;
            Clamper();
            while (timePercentage < 1)
            {
                timePercentage += Time.deltaTime / lerpTime;
                transform.position = Vector3.Lerp(startPos, lerpPositionArray[arrayNumber].transform.position, timePercentage);
                yield return null;

            }
            isWaiting = false;
        }
        private IEnumerator MoveToNextPositionToTheRight()
        {
            isWaiting = true;
            float timePercentage = 0f;
            Vector3 startPos = transform.position;
            arrayNumber++;
            Clamper();
            while (timePercentage < 1)
            {
                timePercentage += Time.deltaTime / lerpTime;
                transform.position = Vector3.Lerp(startPos, lerpPositionArray[arrayNumber].transform.position, timePercentage);
                yield return null;


            }
            isWaiting = false;
        }

    }
}