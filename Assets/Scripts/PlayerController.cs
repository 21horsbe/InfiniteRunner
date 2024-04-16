using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;
namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        private InputAction moveAction;
        [SerializeField] private Player playerToMove;
        public void Initialize(InputAction moveAction)
        {
            this.moveAction = moveAction;
            this.moveAction.Enable();
        }

        private void FixedUpdate()
        {
            Vector2 moveAmount = moveAction.ReadValue<Vector2>();
            
            if (moveAmount.x < 0)
            {
                playerToMove.MoveLeft();
            }
            else if (moveAmount.x > 0)
            {
                playerToMove.MoveRight();
            }
            else if (moveAmount.y < 0)
            {
                playerToMove.Slide();
            }
            else if(moveAmount.y > 0)
            {
                playerToMove.Jump();
            }
        }
    }
}