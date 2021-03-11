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

    public GameObject slotHolder;

    void Start()
    {
        allSlots = 25;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
                slot[i].GetComponent<Slot>().empty = true;
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
            else if (item_Script.ID != 1)
            {
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
        for (int i = 0; i < allSlots; i++)
        {
            
            if (slot[i].GetComponent<Slot>().empty)
            {
                Debug.Log("Ice");
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
            }

            return;
        }
    }

}
