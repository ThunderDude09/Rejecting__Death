using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject firePoint;
    private Shooting shooting_Script;

    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool pickedUp;

    //[HideInInspector]
    public bool equipped;
    
    [HideInInspector]
    public GameObject weapon;

    [HideInInspector]
    public GameObject weaponManager;

    public bool playersWeapon;



    public void Start()
    {
        weaponManager = GameObject.FindWithTag("WeaponManager");

        if(!playersWeapon)
        {
            int allWeapons = weaponManager.transform.childCount;
            for (int i = 0; i < allWeapons; i++)
            {
                if (weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
                {
                    weapon = weaponManager.transform.GetChild(i).gameObject;
                }
            }
        }
        shooting_Script = firePoint.GetComponent<Shooting>();
    }
    public void Update()
    {

        if (equipped)
        {
            
        }
    }

    public void ItemUsage()
    {
        if(type == "Weapon")
        {
            if(ID == 1)
            {
                equipped = true;
            }

            //weapon.SetActive(true);
            
        }
    }
}
