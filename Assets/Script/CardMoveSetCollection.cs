using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CardMoveSetCollection 
{
    private readonly HexEngine _engine;
    private Dictionary<CardType, CardMoveSet> _moveSets 
        = new Dictionary<CardType, CardMoveSet>();

    public CardMoveSetCollection(HexBoard board, HexEngine engine)
    {
        _moveSets.Add(CardType.Teleport,
            new CardTeleport(board, engine));
        
        _moveSets.Add(CardType.Slash, 
            new CardSlash(board, engine));

        _moveSets.Add(CardType.Push,
          new CardPush(board, engine));

        _moveSets.Add(CardType.Line,
                    new CardLine(board, engine));

        this._engine = engine;
    }

    public ICardMoveSet For(CardType type) 
    => _moveSets[type];

    internal bool TryGetMoveSet(CardType type, out CardMoveSet moveSet)
        => _moveSets.TryGetValue(type, out moveSet);
}