using UnityEngine;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        [Header("Output")]
        public PlayerController starterAssetsInputs;

        /// <summary>
        /// I only need move
        /// </summary>
        /// <param name="virtualMoveDirection"></param>
        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            starterAssetsInputs.MoveInput(virtualMoveDirection.normalized);
        }
    }
}
