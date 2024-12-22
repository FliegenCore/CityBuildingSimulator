using Assets;
using R3;
using UnityEngine;

namespace Core.Player
{
    [Order(0)]
    public class PlayerController : MonoBehaviour, IControllerEntity
    {
        private const string m_PlayerPrefabName = "PlayerView";

        [Inject] private AssetLoader m_AssetLoader;

        private PlayerView m_PlayerView;

        public void PreInit()
        {
            var playerAsset = m_AssetLoader.LoadSync<PlayerView>(m_PlayerPrefabName);
            m_PlayerView = m_AssetLoader.InstantiateSync(playerAsset, null);
        }

        public void Init()
        {
           
        }

        
    }
}
