using Assets;
using Core.Common;
using UnityEngine;
using Common.Utils;

namespace Core.World
{
    [Order(-50)]
    public class MapController : MonoBehaviour, IControllerEntity
    {
        private const int m_MapSize = 150;

        [Inject] private AssetLoader m_AssetLoader;
        [Inject] private EventManager m_EventManager;

        private MapGenerator m_MapGenerator;
        private Map m_Map;

        public void PreInit()
        {
            m_MapGenerator = new MapGenerator(m_AssetLoader);

            m_Map = m_MapGenerator.Genirate(m_MapSize, m_MapSize);
        }

        public void Init()
        {
            m_EventManager.TriggerEvenet<SetCameraPositionSignal, Vector2>(GetCenterCell().Object.Position);
        }

        public Result<Cell> GetCenterCell()
        {
            Result<Cell> result = new Result<Cell>();

            result = m_Map.GetCenterCell();

            return result;
        }
    }
}
