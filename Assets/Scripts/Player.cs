using System;
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
        [SerializeField] private float limbBaseSpeed = 40;
        [SerializeField] private float speed = 0.01f;

        public int Lane;
        public static int Coins = 0;

        private enum States { JUMPING, SLIDING, SWITCHING, IDLE }
        private States state;
        private float slideCounter = 0;
        private float limbCounter = 0;
        private Vector3 armRotateAround = new Vector3(0, 1.3f, 0);
        private Vector3 legRotateAround = new Vector3(0, .7f, 0);
        private List<Vector3> lanes;

        public void Awake()
        {
            state = States.IDLE;
            Lane = 1;
            lanes = new List<Vector3> { new Vector3(-5, 1, 0), new Vector3(0, 1, 0), new Vector3(5, 1, 0) };
            Coins = 0;
        }

        public void Update()
        {
            var step = speed * Time.deltaTime * LevelManager.speedMult;

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
                slideCounter += LevelManager.speedMult;
                if (slideCounter >= 500)
                {
                    StopSliding();
                }
            }

            if (state == States.SWITCHING || state == States.IDLE)
            {
                MoveLimbs();
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
                Coins++;
                Debug.Log("Score: " + Coins);
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
                transform.localScale = new Vector3(1, .5f, 1);
                transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
                state = States.SLIDING;
                slideCounter = 0;
            }
        }

        private void StopSliding()
        {
            transform.localScale = Vector3.one;
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
        private void MoveLimbs()
        {
            var limbSpeed = Mathf.Clamp(limbBaseSpeed * LevelManager.speedMult, -100, 100);

            Transform rightArm = transform.GetChild(1).GetChild(0);
            Transform leftArm = transform.GetChild(1).GetChild(1);
            rightArm.RotateAround(armRotateAround, Vector3.right, limbSpeed * Time.deltaTime);
            leftArm.RotateAround(armRotateAround, Vector3.right, limbSpeed * Time.deltaTime * -1);


            Transform rightLeg = transform.GetChild(1).GetChild(2);
            Transform leftLeg = transform.GetChild(1).GetChild(3);
            rightLeg.RotateAround(legRotateAround, Vector3.right, limbSpeed * Time.deltaTime * -1);
            leftLeg.RotateAround(legRotateAround, Vector3.right, limbSpeed * Time.deltaTime);

            limbCounter += Time.deltaTime;
            if (limbCounter >= 0.5f)
            {
                limbCounter = -0.5f;
                limbBaseSpeed *= -1;
            }

        }
    }
}
