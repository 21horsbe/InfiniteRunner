using UnityEngine;
using UnityEngine.InputSystem;
namespace HorstmanBen.Lab6
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject playerToMove;
        [SerializeField] private float speed = 0.01f;
        private InputAction moveAction;
        public void Initialize(InputAction moveAction)
        {
            this.moveAction = moveAction;
            this.moveAction.Enable();
        }
        private void FixedUpdate()
        {
            Vector2 moveAmount = moveAction.ReadValue<Vector2>();
            playerToMove.transform.Translate(moveAmount.x * speed, 0, moveAmount.y * speed);
        }
    }
}