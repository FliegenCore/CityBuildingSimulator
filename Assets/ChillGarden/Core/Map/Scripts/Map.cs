using Common.Utils;
using System.Collections.Generic;

namespace Core.World
{
    public class Map
    {
        private readonly int m_Width;
        private readonly int m_Height;

        private List<Cell> m_Cells;

        public Result<Cell> GetCell(int x, int y)
        {
            Result<Cell> result = new Result<Cell>();

            foreach (var cell in m_Cells)
            {
                if (cell.Position.x == x && cell.Position.y == y)
                { 
                    result = new Result<Cell>(cell, true);
                    break;
                }
            }

            return result;
        }

        public Result<Cell> GetCenterCell()
        {
            Result<Cell> result = new Result<Cell>();

            int centerX = m_Width / 2;
            int centerY = m_Height / 2;

            result = GetCell(centerX, centerY);

            return result;
        }

        public Map(int x, int y)
        {
            int size = x * y;
            m_Width = x;
            m_Height = y;
            m_Cells = new List<Cell>(size);
        }

        public void AddCell(Cell cell)
        {
            if (m_Cells.Contains(cell))
            {
                return;
            }
            m_Cells.Add(cell);
            cell.name = $"cell {cell.Position.x} : {cell.Position.y}";
            Colorize(cell);
        }

        private void Colorize(Cell cell)
        {
            if (cell.Position.x % 2 == 0)
            {
                if (cell.Position.y % 2 == 0)
                {
                    cell.SetColor(ColorMap.DarkGreen);
                }
                else
                { 
                    cell.SetColor(ColorMap.LightGreen);
                }
            }
            else
            {
                if (cell.Position.y % 2 == 0)
                {
                    cell.SetColor(ColorMap.LightGreen);
                }
                else
                { 
                    cell.SetColor(ColorMap.DarkGreen);
                }
            }
        }
    }
}
