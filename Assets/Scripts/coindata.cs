using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class coindata 
{
    public int coin;
    public bool btt;
    // Start is called before the first frame update
    public coindata(ShopManager shopManager)
    {
        coin = shopManager.coins;
        btt = shopManager.bt;
    }
}
