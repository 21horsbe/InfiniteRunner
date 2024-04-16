using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class ObstacleFactory: MonoBehaviour
    {
        [SerializeField] private GameObject fullObstaclePrefab;
        [SerializeField] private GameObject lowObstaclePrefab;
        [SerializeField] private GameObject highObstaclePrefab;
        [SerializeField] private GameObject coinPrefab;
        private System.Random rand;
        public void Start()
        {
            rand = new System.Random((int) DateTime.Now.TimeOfDay.TotalMilliseconds);
        }
        public void SpawnNextWave()
        {
            int numObstacles = 0;

            for (int i = -1; i < 2; i++)
            {
                if (numObstacles == 2) break;

                int random = (int) (rand.NextDouble() * 5);
                switch (random)
                {
                    case 0:
                        var prefab = GameObject.Instantiate<GameObject>(fullObstaclePrefab, new Vector3(5f * i, 2, 140), Quaternion.identity);
                        prefab.name = "Full Obstacle" + (i + 1);
                        prefab.AddComponent<Obstacle>();
                        numObstacles++;
                        break;
                    case 1:
                        var prefab1 = GameObject.Instantiate<GameObject>(lowObstaclePrefab, new Vector3(5f * i, 1, 140), Quaternion.identity);
                        prefab1.name = "Low Obstacle" + (i + 1);
                        prefab1.AddComponent<Obstacle>();
                        numObstacles++;
                        break;
                    case 2:
                        var prefab2 = GameObject.Instantiate<GameObject>(highObstaclePrefab, new Vector3(5f * i, 2.5f, 140), Quaternion.identity);
                        prefab2.name = "High Obstacle" + (i + 1);
                        prefab2.AddComponent<Obstacle>();
                        numObstacles++;
                        break;
                    case 3:
                        var prefab3 = GameObject.Instantiate<GameObject>(coinPrefab, new Vector3(5f * i, 1, 140), Quaternion.Euler(90, 0, 0));
                        prefab3.name = "Coin Obstacle" + (i + 1);
                        prefab3.AddComponent<Obstacle>();
                        break;
                    default:
                        // Empty space
                        break;

                }
            }
        }
    }
}
