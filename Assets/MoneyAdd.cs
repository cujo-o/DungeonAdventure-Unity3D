using UnityEngine;

public class MoneyAdd : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ShopSaveManager.instance.money += 100;
            ShopSaveManager.instance.Save();
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            ShopSaveManager.instance.money -= 100;
            ShopSaveManager.instance.Save();
        }
    }
}