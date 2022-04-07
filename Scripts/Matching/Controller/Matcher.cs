using System;
using System.Collections;
using Matching.Model;
using Matching.View;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Matching.Controller
{
    public class Matcher : MonoBehaviour
    {
        [SerializeField] private GameObject cell;
        private Player _player;

        private int _firstValue;
        
        private void Start() 
        {
            FindObjectOfType<GridGenerator>().GenerateMap(Map.map, cell);
            _player = FindObjectOfType<Player>();
        }
        
        public void OnClick(Cell[,] cells , int posX, int posY)
        {
            _firstValue = cells[posY, posX].colorType;

            TraverseMatches(cells, posX, posY);
        }
        
        private IEnumerator ConfirmMatch(int posX, int posY)
        {
            Map.cells[posY, posX].gameObject.transform.DOScale(new Vector3(0, 0, 0), Map.Delay);
            _player.OnClickOccur();
            yield return new WaitForSeconds(Map.Delay);  //As you may have guessed algorithm must finish before N seconds.
            Map.cells[posY, posX].AssignRandomColor()
                                    .ResetVisitStatus();
            
            Map.cells[posY, posX].gameObject.transform.DOScale(new Vector3(1, 1, 1), Map.Delay);
        }

        private void TraverseMatches(Cell[,] cells , int posX, int posY)
        {
            cells[posY, posX].isVisited = CellState.Visited;

            StartCoroutine(ConfirmMatch(posX, posY));

            if (CheckUp(posX, posY, cells) && cells[posY - 1, posX].isVisited == CellState.NotVisited)
            {
                TraverseMatches(cells, posX, posY - 1);
            }

            if (CheckLeft(posX, posY, cells) && cells[posY, posX - 1].isVisited == CellState.NotVisited)
            {
                TraverseMatches(cells, posX - 1, posY);  
            }
            
            if (CheckDown(posX, posY, cells) && cells[posY + 1, posX].isVisited == CellState.NotVisited)                           
            {                                                                                                        
                TraverseMatches(cells, posX, posY + 1);                                                
            }                                                                                                        
                                                                                                                     
            if (CheckRight(posX, posY, cells) && cells[posY, posX + 1].isVisited == CellState.NotVisited)                         
            {                                                                                                        
                TraverseMatches(cells, posX + 1, posY);                                                
            }
        }

        private bool CheckUp(int posX, int posY, Cell[,] cells)
        {
            return posY != 0 && cells[posY - 1, posX].colorType == _firstValue;
        }

        private bool CheckDown(int posX, int posY, Cell[,] cells)
        {
            return posY != (int)(Math.Sqrt(cells.Length) - 1) && cells[posY + 1, posX].colorType == _firstValue;
        }

        private bool CheckLeft(int posX, int posY, Cell[,] cells)
        {
            return posX != 0 && cells[posY, posX - 1].colorType == _firstValue;
        }
        
        private bool CheckRight(int posX, int posY, Cell[,] cells)
        {
            return posX != (int)(Math.Sqrt(cells.Length) - 1) && cells[posY, posX + 1].colorType == _firstValue;
        }
    }
}
