using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Unity.FPS.UI
{
    public class MenuNavigation : MonoBehaviour
    {
        public Selectable DefaultSelection;

        void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            EventSystem.current.SetSelectedGameObject(null);
        }

        void LateUpdate()
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                if (ControlFreak2.CF2Input.GetButtonDown(GameConstants.k_ButtonNameSubmit)
                    || ControlFreak2.CF2Input.GetAxisRaw(GameConstants.k_AxisNameHorizontal) != 0
                    || ControlFreak2.CF2Input.GetAxisRaw(GameConstants.k_AxisNameVertical) != 0)
                {
                    EventSystem.current.SetSelectedGameObject(DefaultSelection.gameObject);
                }
            }
        }
    }
}