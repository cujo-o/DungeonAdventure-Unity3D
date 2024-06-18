using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipmentSysytem : MonoBehaviour
{
    public GameObject[] equipments;

    public float armor = 2f;
    public bool equip = false;
   // private bool unequip;

    public void Equip()
    {

        for (int i = 0; i < equipments.Length; i++)
        {
            equipments[i].SetActive(false);
          //  Saveequipment();
        }
        equip = true;

        ShopSaveManager.instance.equip = true;
       
        if (equip == true)
        {
           
            gameObject.SetActive(true);
        }
        else
        {
            return;
        }

        ShopSaveManager.instance.Save();

    }


    void Start()
    {
        equip = ShopSaveManager.instance.equip;
    }

  
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
           
        }

      

    }


}
