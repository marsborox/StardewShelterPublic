using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTaskSequencer : MonoBehaviour
{
    
    // go somewhere --- do stuff --- do it till when--- return to base --- drop loot --- repeat???
    //
    //main AI initiates 
    //need to input where we go and what will be our task for how long (inventory full)




    HeroTravel heroTravel;
    private void Awake()
    {
        heroTravel = GetComponent<HeroTravel>();
    }


    void GoAdventuring(GameObject destinationArea)
    { 
        
    }
    
}
