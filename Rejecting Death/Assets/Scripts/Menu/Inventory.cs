 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject firePoint;
    private Shooting shooting_Script;

    public GameObject TheFireItem;
    private Item item_Script;

    private bool inventoryEnabled = false;
    public GameObject inventory;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    private bool isItEmpty = false;

    private int allSlots2;
    private int enabledSlots2;
    private GameObject[] slot2;

    public GameObject slotHolder;

    void Start()
    {
        allSlots = 25;
        slot = new GameObject[allSlots];

        allSlots2 = 24;
        slot2 = new GameObject[allSlots2];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
                slot[i].GetComponent<Slot>().empty = true;
        }

        for (int j = 1; j < allSlots2; j++)
        {
            slot[j] = slotHolder.transform.GetChild(j).gameObject;

            if (slot[j].GetComponent<Slot>().item == null)
                slot[j].GetComponent<Slot>().empty2 = true;
        }
        shooting_Script = firePoint.GetComponent<Shooting>();

        item_Script = TheFireItem.GetComponent<Item>();
    }

    void Update()
    {

        if (item_Script.equipped)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                //shooting_Script.HasFire = false;
                //Debug.Log("Hello");
            }
            if (item_Script.ID == 1)
            {
                shooting_Script.HasFire = true;
            }

            if (item_Script.ID == 2)
            {
                Debug.Log("Ice");
                shooting_Script.HasFire = false;
            }
        }

        /*for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().hasWeaponEquipped == true)
                shooting_Script.HasFire = true;
        }*/

        if (Input.GetKeyDown(KeyCode.E))
            inventoryEnabled = !inventoryEnabled;
        
        if(inventoryEnabled == true)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(collision.tag == "Item")
        {
            GameObject ItemPickedUp = collision.gameObject;
            Item item = ItemPickedUp.GetComponent<Item>();

            AddItem(ItemPickedUp, item.ID, item.type, item.description, item.icon);
        }*/

        if (collision.gameObject.CompareTag("Sickle"))
        {
            //shooting_Script.HasFire = true;
            //Destroy(collision.gameObject);

            GameObject ItemPickedUp = collision.gameObject;
            Item item = ItemPickedUp.GetComponent<Item>();

            AddItem(ItemPickedUp, item.ID, item.type, item.description, item.icon);
        }

        if (collision.gameObject.CompareTag("IceGem"))
        {
            //shooting_Script.HasFire = true;
            //Destroy(collision.gameObject);

            GameObject ItemPickedUp = collision.gameObject;
            Item item = ItemPickedUp.GetComponent<Item>();

            AddItem(ItemPickedUp, item.ID, item.type, item.description, item.icon);
        }
    }

    void AddItem(GameObject  itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        if(isItEmpty == false)
        {
            for (int i = 0; i < allSlots; i++)
            {

                if (slot[i].GetComponent<Slot>().empty)
                {
                    
                    itemObject.GetComponent<Item>().pickedUp = true;

                    slot[i].GetComponent<Slot>().item = itemObject;
                    slot[i].GetComponent<Slot>().icon = itemIcon;
                    slot[i].GetComponent<Slot>().type = itemType;
                    slot[i].GetComponent<Slot>().ID = itemID;
                    slot[i].GetComponent<Slot>().description = itemDescription;

                    itemObject.transform.parent = slot[i].transform;
                    itemObject.SetActive(false);

                    slot[i].GetComponent<Slot>().UpdateSlot();
                    slot[i].GetComponent<Slot>().empty = false;
                    isItEmpty = true;
                }

                return;
            }
        }
        else
        {
            for (int j = 1; j < allSlots2; j++)
            {

                if (slot[j].GetComponent<Slot>().empty2)
                {
                    
                    itemObject.GetComponent<Item>().pickedUp = true;

                    slot[j].GetComponent<Slot>().item = itemObject;
                    slot[j].GetComponent<Slot>().icon = itemIcon;
                    slot[j].GetComponent<Slot>().type = itemType;
                    slot[j].GetComponent<Slot>().ID = itemID;
                    slot[j].GetComponent<Slot>().description = itemDescription;

                    itemObject.transform.parent = slot[j].transform;
                    itemObject.SetActive(false);

                    slot[j].GetComponent<Slot>().UpdateSlot();
                    slot[j].GetComponent<Slot>().empty2 = false;
                }

                return;
            }
        }

        
    }

}
