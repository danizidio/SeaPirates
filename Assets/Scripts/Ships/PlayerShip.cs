using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public void ShipWrecked()
    {
        GameBehaviour.OnNextGameState.Invoke(GamePlayStates.GAMEOVER);
    }
}
