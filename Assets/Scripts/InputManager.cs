using HorstmanBen;
using UnityEngine;
namespace HorstmanBen.Lab6
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        private PlayerInput inputScheme;
        private ResetHandler resetHandler;
        private void Awake()
        {
            inputScheme = new PlayerInput();
            playerController.Initialize(inputScheme.Player.Move);
            resetHandler = new ResetHandler(inputScheme.Player.Reset);
        }
        private void OnEnable()
        {
            var _ = new QuitHandler(inputScheme.Player.Quit);
        }
    }
}
