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
        [SerializeField] private GameObject obstaclePrefab;
        private List<GameObject> environment = new List<GameObject>();
        private List<GameObject> obstacles;
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
    }
}
