﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HexEngine   
{
    public HexPosition PlayerPosition { get; set; } //FromPosition will always be PlayerPostion //If Player moved do it here too

    private HexBoard _hexBoard;
    private CardMoveSetCollection _cardMoveSetCollection;


    public HexEngine(HexBoard board)
    {
        _hexBoard = board;
        _cardMoveSetCollection = new CardMoveSetCollection(_hexBoard, this); 
    }

    public CardMoveSetCollection MoveSets
    {
        get
        {
            return _cardMoveSetCollection;
        }
    }    
    
    public bool Drop(CardView cardView, HexPosition hoverPosition) // accept card instead of cardtype //REVISE
    {    
        if (!_hexBoard.IsValid(hoverPosition)) //Is a valid position
            return false;      

        if (!MoveSets.TryGetMoveSet(cardView.Type, out var moveSet)) //Is a moveset to use
            return false;

        if (!moveSet.Positions(hoverPosition).Contains(hoverPosition)) //Is Valid and Movset coincide
            return false;

        if (!moveSet.Execute(hoverPosition, cardView)) // pass card to Moveset FOR WHAT? 
            return false;

        return true;
    }    
}

