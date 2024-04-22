using UnityEditor;
using UnityEngine;
namespace Assets.Scripts
{
    public class EnvironmentPiece: MovingObject
    {
        public Vector3 resetSpot = new Vector3 (0, 0, -20);
        [SerializeField] float speed = 10f;

        public void Start()
        {
        }

        public void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, resetSpot, speed * Time.deltaTime * LevelManager.speedMult);

            if (transform.position == resetSpot)
            {
                ResetPosition();
            }
        }

        public void ResetPosition()
        {
            transform.position = new Vector3(0, 0, 140);
        }
    }
}
