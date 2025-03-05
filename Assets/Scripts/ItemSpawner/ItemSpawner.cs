using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField] Item lootBox;
    [SerializeField] Item sword;


    Item itemToAdd;


    MainUI mainUI;
    // Start is called before the first frame update

    private void Awake()
    {
        mainUI = FindObjectOfType<MainUI>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CraftSwordToClickedHero()
    {
        if (mainUI.activeUnit != null)
        {
            //CraftItem(mainUI.activeUnit, _sword);
            AddItemToActiveHero(sword);
        }
    }
    public void CraftBoxToClickedHero()
    {
        if (mainUI.activeUnit != null)
        {
            //CraftItem(mainUI.activeUnit, _lootBox);
            AddItemToActiveHero(lootBox);
        }
    }

    public void AddItemToActiveHero(Item item)
    {
        if (mainUI.activeUnit != null)
        {
            mainUI.activeUnit.GetComponent<BackPack>().AddItemToBackPack(item);
        }
    }
    public void CraftItem(GameObject hero, Item item)
    {
        hero.GetComponent<BackPack>().items.Add(item);
    }
}
