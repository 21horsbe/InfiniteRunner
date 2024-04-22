using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEditorInternal.VR;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class LevelManager: MonoBehaviour
    {
        [SerializeField] private GameObject environmentPrefab;
        [SerializeField] private ObstacleFactory obstacleFactory;
        [SerializeField] private GameObject uiCanvas;

        public static float speedMult = 1;
        private float nextWave = 0;
        private int score;
        private TextMeshProUGUI uiText;
        private List<GameObject> environment = new List<GameObject>();

        void Start()
        {
            for (int i = 0; i < 8; i++)
            {
                var prefab = GameObject.Instantiate<GameObject>(environmentPrefab, Vector3.forward * i * 20f, Quaternion.identity);
                prefab.name = "Environment" + i;
                prefab.AddComponent<EnvironmentPiece>();
                environment.Add(prefab);
            }

            // Example code from Unity Docs. UI object.
            var myText = new GameObject();
            myText.transform.parent = uiCanvas.transform;
            myText.name = "UI";

            uiText = myText.AddComponent<TextMeshProUGUI>();
            uiText.text = "Score: 0\nCoins: 0";
            uiText.fontSize = 30;

            // Text position
            var rectTransform = uiText.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, 0, 0);
            rectTransform.sizeDelta = new Vector2(700, 400);

            speedMult = 1;
        }

        private void Update()
        {
            nextWave += Time.deltaTime;
            if(nextWave > 2 / speedMult)
            {
                nextWave = 0;
                obstacleFactory.SpawnNextWave();
                speedMult += 0.05f;
            }

            score++;
            uiText.text = "Score: " + score + "\nCoins: " + Player.Coins;
        }
    }
}
