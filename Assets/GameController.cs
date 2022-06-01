using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerCollision mag;
    public PlayerCollision arc;
    public PlayerCollision swo;

    public Menu menu;

    // Update is called once per frame
    void Update()
    {
        if(mag.magAlive==false && arc.arcAlive==false)
        {
            Debug.Log("Swordsman wins");
            menu.ToCreditsSwo();
        }

        if (mag.magAlive == false && swo.swoAlive == false)
        {
            Debug.Log("Archer wins");
            menu.ToCreditsArc();
        }

        if (swo.swoAlive == false && arc.arcAlive == false)
        {
            Debug.Log("Magician wins");
            menu.ToCreditsMag();
        }
    }
}
