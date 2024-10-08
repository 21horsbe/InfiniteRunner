﻿using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
namespace Assets.Scripts { 
    public class ResetHandler
    {
        public ResetHandler(InputAction resetAction)
        {
            resetAction.performed += ResetAction_performed;
            resetAction.Enable();
        }
        private void ResetAction_performed(InputAction.CallbackContext obj)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
