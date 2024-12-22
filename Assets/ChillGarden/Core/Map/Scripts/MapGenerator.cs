using Assets;
using UnityEngine;

namespace Core.World
{
    [Order(-100)]
    public class MapGenerator
    {
        private const string m_CellAssetName = "Cell";

        private GameObject m_MapParent;
        private Map m_Map;
        private AssetLoader m_AssetLoader;

        private int[,] m_MapSize;

        public MapGenerator(AssetLoader assetLoader)
        {
            m_AssetLoader = assetLoader;
        }
        
        //TODO: change to async instantiate
        public Map Genirate(int wight, int height)
        {
            m_MapParent = new GameObject("Map");

            m_MapSize = new int[wight, height];
            Map map = new Map(wight, height);
            Cell cellAsset = m_AssetLoader.LoadSync<Cell>(m_CellAssetName);

            for (int x = 0; x < wight; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cell cell = m_AssetLoader.InstantiateSync(cellAsset, 
                        new Vector2(x, y), Quaternion.identity, m_MapParent.transform);

                    map.AddCell(cell);
                }
            }

            return map;
        }
    }
}
