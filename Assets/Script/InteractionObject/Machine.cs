using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MoveType
{
    Horizon,
    Verticle,
    Rotation
}
public class Machine : InteractionObject
{
    public Gear targetGear;
    public MoveType moveType;
    public int chageIndex = 1;
    public override void OnInteraction(KeyCode inputKey)
    {
        base.OnInteraction(inputKey);
        switch (moveType)
        {
            case MoveType.Horizon:
                targetGear.ChangeHorizon(chageIndex);
                break;
            case MoveType.Verticle:
                targetGear.ChangeVerticle(chageIndex);
                break;
            case MoveType.Rotation:
                targetGear.ChangeRotation(chageIndex);
                break;
                
        }
    }
}