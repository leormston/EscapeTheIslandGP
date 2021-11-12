using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftableItem : MonoBehaviour
{
    //this is for generating items
    public string itemName;
    public int woodRequired;
    public int stoneRequired;
    public int scrapRequired;

    // Start is called before the first frame update

    public CraftableItem(string name, int wood, int stone, int scrap)
    {
        itemName = name;
        woodRequired = wood;
        stoneRequired = stone;
        scrapRequired = scrap;
    }
    // Start is called before the first frame update
    
}
