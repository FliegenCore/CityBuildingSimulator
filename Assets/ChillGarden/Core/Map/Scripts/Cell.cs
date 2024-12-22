using UnityEngine;

namespace Core.World
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer m_SpriteRender;

        public Vector2Int Position { get => new Vector2Int((int)transform.position.x, (int)transform.position.y); }

        public void SetColor(Color color)
        {
            m_SpriteRender.color = color;
        }
    }
}
