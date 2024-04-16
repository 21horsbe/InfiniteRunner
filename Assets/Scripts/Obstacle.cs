using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Obstacle: MonoBehaviour
    {
        private float speed = 10f;
        private Vector3 resetSpot;
        public void Awake()
        {
            resetSpot = new Vector3(transform.position.x, transform.position.y, -20);
        }
        public void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, resetSpot, speed * Time.deltaTime);

            if (transform.position == resetSpot)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
