using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditorInternal.VR;
using UnityEngine;

namespace Assets.Scripts
{
    public class LevelManager: MonoBehaviour
    {
        [SerializeField] private GameObject environmentPrefab;
        [SerializeField] private ObstacleFactory obstacleFactory;
        private List<GameObject> environment = new List<GameObject>();
        private float nextWave = 0;

        void Start()
        {
            for (int i = 0; i < 8; i++)
            {
                var prefab = GameObject.Instantiate<GameObject>(environmentPrefab, Vector3.forward * i * 20f, Quaternion.identity);
                prefab.name = "Environment" + i;
                prefab.AddComponent<EnvironmentPiece>();
                environment.Add(prefab);
            }
        }

        private void Update()
        {
            nextWave += Time.deltaTime;
            if(nextWave > 2)
            {
                nextWave = 0;
                obstacleFactory.SpawnNextWave();
            }
        }
    }
}
