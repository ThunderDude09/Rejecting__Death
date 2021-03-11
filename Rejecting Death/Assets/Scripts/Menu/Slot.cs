using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public GameObject firePoint;
    private Shooting shooting_Script;

    public GameObject TheFireItem;
    private Item item_Script;

    public GameObject item;
    public int ID;
    public string type;
    public string description;
    public bool empty;

    public bool empty2;


    public Transform slotIconGO;
    public Sprite icon;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        UseItem();
        if (ID == 2)
        {
            item_Script.equipped = false;
            shooting_Script.HasFire = false;
        }
        
    }

    private void Start()
    {
        slotIconGO = transform.GetChild(0);
        shooting_Script = firePoint.GetComponent<Shooting>();

        item_Script = TheFireItem.GetComponent<Item>();
    }

    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = icon;
    }

    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();

        
    }
}
