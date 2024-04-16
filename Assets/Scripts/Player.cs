﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public int Lane;
        public int Score = 0;
        private enum States { JUMPING, SLIDING, SWITCHING, IDLE }
        private States state;
        private List<Vector3> lanes;
        [SerializeField] private float speed = 0.01f;
        private int slideCounter = 0;

        public void Awake()
        {
            state = States.IDLE;
            Lane = 1;
            lanes = new List<Vector3> { new Vector3(-5, 1, 0), new Vector3(0, 1, 0), new Vector3(5, 1, 0) };
        }

        public void Update()
        {
            var step = speed * Time.deltaTime;

            if (state == States.SWITCHING)
            {
                transform.position = Vector3.MoveTowards(transform.position, lanes[Lane], step);
            }

            if (AtRest())
            {
                state = States.IDLE;
            }

            if (state == States.SLIDING)
            {
                slideCounter++;
                if (slideCounter == 500)
                {
                    StopSliding();
                }
            }

        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                Score++;
                Debug.Log("Score: " + Score);
                Destroy(other.gameObject);
            }
        }

        public void MoveLeft() {
            if (state == States.IDLE && Lane != 0)
            {
                state = States.SWITCHING;
                Lane--;
            }
        }
        public void MoveRight() {
            if (state == States.IDLE && Lane != 2)
            {
                state = States.SWITCHING;
                Lane++;
            }
        }
        public void Jump() {
            if (state == States.IDLE)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 8, ForceMode.Impulse);
                state = States.JUMPING;
            }
        }
        public void Slide()
        {
            if (state == States.IDLE) 
            { 
                transform.localScale = Vector3.one;
                transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
                state = States.SLIDING;
                slideCounter = 0;
            }
        }

        private void StopSliding()
        {
            transform.localScale = new Vector3(1,2,1);
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
            state = States.IDLE;
        }

        private bool AtRest()
        {
            Vector3 diff = transform.position - lanes[Lane];
            if(Math.Abs(diff.x) < 0.05 
                && Math.Abs(diff.y) < 0.05
                && Math.Abs(diff.z) < 0.05)
            {
                return true;
            }

            return false;
        }
    }
}
