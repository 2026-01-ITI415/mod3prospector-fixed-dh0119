using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eCardStateGolf { drawpile, tableau, target, discard }

public class CardGolf : Card
{
    [Header("Dynamic: CardGolf")]
    public eCardStateGolf state = eCardStateGolf.drawpile;
    // The hiddenBy list stores which other cards will cover this one
    public List<CardGolf> hiddenBy = new List<CardGolf>();
    // The layoutID matches this card to the tableau JSON if it’s a tableau card
    public int layoutID;
    // The JsonLayoutSlot class stores information pulled in from JSON_Layout
    public JsonLayoutSlot layoutSlot;


    public bool IsAvailable
    {
        get
        {
            foreach (CardGolf cg in hiddenBy)
            {
                if (cg == null) continue;
                if (cg.state == eCardStateGolf.tableau) return false;
            }
            return faceUp;
        }
    }


    public bool AdjacentToGolf(Card otherCard, bool wrap = false)
    {
        if (!faceUp || !otherCard.faceUp) return (false);

        if (Mathf.Abs(rank - otherCard.rank) == 1) return (true);

        if (wrap)
        { 
            if (rank == 1 && otherCard.rank == 13) return (true);
            if (rank == 13 && otherCard.rank == 1) return (true);
        }

        return (false);
    }

    override public void OnMouseUpAsButton()
    {
        Debug.Log("CardGolf clicked: " + name);
        base.OnMouseUpAsButton();
    }
}
