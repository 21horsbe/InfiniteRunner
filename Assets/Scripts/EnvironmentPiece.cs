using UnityEditor;
using UnityEngine;
namespace Assets.Scripts
{
    public class EnvironmentPiece: MonoBehaviour
    {
        public Vector3 resetSpot = new Vector3 (0, 0, -20);
        [SerializeField] float speed = 10f;

        public void Start()
        {
        }

        public void Update()
        {
            // Slide towards the player until out of frame, then respawn at the back of the line.
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
