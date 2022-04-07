using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Matching.Model
{
    public class Cell
    {
        public int colorType;
        public GameObject gameObject;
        public CellState isVisited;

        public Cell(int colorType, GameObject gameObject)
        {
            this.colorType = colorType;
            this.gameObject = gameObject;
        }

        public Cell AssignRandomColor()
        {
            colorType = Random.Range(1, Map.ColorMapping.Length + 1);
            gameObject.GetComponent<Image>().color = Map.ColorMapping[colorType - 1];
            return this;
        }

        public Cell ResetVisitStatus()
        {
            isVisited = CellState.NotVisited;
            return this;
        }
    }
    
    public enum CellState
    {
        NotVisited,
        Visited
    }
}