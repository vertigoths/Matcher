using System;
using Matching.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Matching.View
{
    public class GridGenerator : MonoBehaviour  
    {
        public void GenerateMap(int[,] map, GameObject cellObject)
        {
            for (var i = 0; i < Math.Sqrt(map.Length); i++)
            {
                for (var j = 0; j < Math.Sqrt(map.Length); j++)
                {
                    var generatedCell = Instantiate(cellObject, this.transform, false);
                    generatedCell.GetComponent<Image>().color = Map.ColorMapping[map[i,j] - 1];
                    generatedCell.name = "(" + i + "," + j + ")";
                    
                    AssignCells(map, j, i, generatedCell);
                }
            }
        }

        private void AssignCells(int[,] map, int posX, int posY, GameObject generatedCell)
        {
            var cell = new Cell(map[posY, posX], generatedCell);
            Map.cells[posY, posX] = cell;
        }
    }
}
