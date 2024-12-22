using Core.Common;
using UnityEngine;

namespace Core.World
{
    [Order(-150)]
    public class CameraController : MonoBehaviour, IControllerEntity
    {
        [Inject] private EventManager m_EventManager;

        private Transform m_Camera;

        public void PreInit()
        {
            m_Camera = GameObject.Find("CameraRoot").transform;
        }

        public void Init()
        {
            m_EventManager.Subscribe<SetCameraPositionSignal, Vector2>(this, SetPosition);
        }

        private void SetPosition(Vector2 pos)
        { 
            m_Camera.position = pos;
        }

        private void OnDestroy()
        {
            m_EventManager.Unsubscribe<SetCameraPositionSignal>(this);
        }
    }
}
