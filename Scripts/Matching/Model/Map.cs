using UnityEngine;

namespace Matching.Model
{
    public static class Map
    {
        public static int[,] map = {{1,1,1,1,1,2,2,2,2},
            {2,2,3,2,2,1,1,2,2},
            {3,3,3,3,3,3,3,3,2},
            {2,2,3,2,2,1,1,1,2},
            {1,1,3,1,1,2,2,2,2},
            {2,2,3,2,2,1,1,1,2},
            {3,3,3,3,3,3,3,3,2},
            {2,2,3,2,2,1,1,2,2},
            {1,1,1,1,1,2,2,2,2}
        };

        public static readonly Color[] ColorMapping = {Color.red, Color.green, Color.blue};

        public static Cell[,] cells = new Cell[map.GetLength(0), map.GetLength(1)];

        public static readonly float Delay = .25f;
    }
}
