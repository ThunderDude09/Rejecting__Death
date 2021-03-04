 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject firePoint;
    private Shooting shooting_Script;

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
        }
        shooting_Script = firePoint.GetComponent<Shooting>();
    }

    void Update()
    {
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
        if (collision.gameObject.CompareTag("Gem"))
        {
            shooting_Script.HasFire = true;
            Destroy(collision.gameObject);

            //AddItem(itemID, item.type, item.description, itemIcon);
        }
    }

}
