using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlash : CardMoveSet
{
    private int _radius = 1;

    private static List<Vector2Int> _directions = new List<Vector2Int>()
    {
        new Vector2Int(+1, 0), new Vector2Int(+1, -1), new Vector2Int(0, -1),
        new Vector2Int(-1, 0),new Vector2Int(-1, +1), new Vector2Int(0, +1)
    };
    public CardSlash(HexBoard board, HexEngine engine) : base(board, engine)
    {
    }

    public override bool Execute(HexPosition hoverPosition, CardView cardView) 
    {
        var validPositions = Positions(hoverPosition);
        if (!validPositions.Contains(hoverPosition))
            return false;

        foreach (var validPosition in validPositions)
        {
            HexBoard.Take(validPosition); 
        }

        return true;
    }

    public override List<HexPosition> Positions(HexPosition hoverPosition) 
    {
        var validPositions = new List<HexPosition>();

        Vector2Int initialDirection = _directions[4] ; // +1 -1

        var currentPosition = new HexPosition //Offset in corner 4 added
            (HexEngine.PlayerPosition.Q + initialDirection.x, 
            HexEngine.PlayerPosition.R + initialDirection.y);

        // var hex = cube_add(center, cube_scale(cube_direction(4), radius)) //WHAT IS THIS PART?

            for (int i = 0; i < 6; i++)
            {
                Vector2Int direction = _directions[i];
                for (int j = 0;  j < _radius; j++)
                {
                   validPositions.Add(currentPosition);
                   currentPosition = new HexPosition(currentPosition.Q + direction.x, currentPosition.R + direction.y);
                }
            }

        if (validPositions.Contains(hoverPosition)) //REVISE
        {
            List<HexPosition> filteredValidPositions = new List<HexPosition>();
            foreach(var validPosition in validPositions)
            {
                if (validPosition.Equals(hoverPosition) || CheckRange(hoverPosition, validPosition) == 1) 
                    filteredValidPositions.Add(validPosition);
            }
            return filteredValidPositions;
        }

        return validPositions;
    }

    private int CheckRange(HexPosition hoverPosition, HexPosition validPosition) //CORRECT? 
    {
        
        return (Mathf.Abs(hoverPosition.Q - validPosition.Q)
          + Mathf.Abs(hoverPosition.Q + hoverPosition.R - validPosition.Q - validPosition.R)
          + Mathf.Abs(hoverPosition.R - validPosition.R)) / 2;
    }
}
