
using System.Collections.Generic;

using UnityEngine;


public class BackPackUI : MonoBehaviour
{
    // Start is called bef
    //
    //
    // the first frame update

    MainUI mainUI;
    
    [SerializeField] ItemSlot itemSlotPrefab;
    public int spawnedSlots;
    public int numberOfSlotsToSpawn;


    private void Awake()
    {
        mainUI = FindObjectOfType<MainUI>();
    }
    void Start()
    {
        //numberOfSlotsToSpawn = mainUI.activeUnit.GetComponent<BackPack>().items.Count;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnSlots();
    }
    private void OnEnable()
    {

    }
    private void OnDisable()
    {
        ReloadSlots();
    }

    void SpawnSlots()
    {
        if (mainUI.activeUnit == null)
        {
            return;
        }
        //will need to check if we clicked other hero prob over refresh ui method
        numberOfSlotsToSpawn = mainUI.activeUnit.GetComponent<BackPack>().items.Count;
        SlotSpawning(mainUI.activeUnit.GetComponent<BackPack>().items);
    }

    public void SlotSpawning(List<Item> itemList)
    {
        if (!(spawnedSlots == numberOfSlotsToSpawn))
        {
            DestroySlots();
            spawnedSlots = numberOfSlotsToSpawn;
            //Debug.Log("Change Detected");
            //Debug.Log(numberOfSlotsToSpawn);
            for (int i = 0; i < numberOfSlotsToSpawn; i++)

            {
                ItemSlot itemSlot = Instantiate(itemSlotPrefab);
                //Display IMG ---     first is from tutorial but i like second one more for...reasons
                //itemSlot.transform.GetChild(0).GetComponent<Image>().sprite = _mainUI.activeUnit.GetComponent<BackPack>().items[i].itemIcon;

                //itemSlot.GetComponent<ItemSlot>().image.sprite = mainUI.activeUnit.GetComponent<BackPack>().items[i].itemIcon;

                itemSlot.GetComponent<ItemSlot>().image.sprite = itemList[i].itemIcon;

                itemSlot.transform.parent = transform;
            }
        }
    }

    void DestroySlots()
    {//**make class to kill all buttons put into areas too
        for (var i = transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(transform.GetChild(i).gameObject);
        }
    }
    public void ReloadSlots()
    {//we will never have this much of slots as inventory
        //if hope
        spawnedSlots = 9999999;
    }
}
