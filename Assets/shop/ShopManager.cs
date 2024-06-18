using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int coins;
  //  public TMP_Text coinUI;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopPanel[] shopPanels;
    public Button[] myPurchaseBtns;

    public Button[] equipbtns;

   public bool bt=false;


    // Start is called before the first frame update
    void Start()
    {
       
      
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }
       // coinUI.text = "Coins: " + coins.ToString();
        LoadPanels();
        CheckPurchaseable();
         // Loadcoins();


    }


    public void AddCoins() // simple script to add coins.
    {
        coins+=50;
       // Savecoins();
      //  coinUI.text = "Coins: " + coins.ToString();
        CheckPurchaseable();
        
    }

    public void Savecoins()
    {
        CoinSaveSystem.Savecoin(this);
    }

    public void Loadcoins()
    {
        coindata data = CoinSaveSystem.loadData();
        coins = data.coin;
        bt = data.btt;
        
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coins >= shopItemsSO[i].itemPrice) //if i have enough money.
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
           
        }
    }
  
    public void PurchaseItem(int btnNo)
    {
        if (coins >= shopItemsSO[btnNo].itemPrice)
        {
            coins = coins - shopItemsSO[btnNo].itemPrice;
          //  coinUI.text = "Coins: " + coins.ToString();
            bt = true;
            if (bt == true)
            {
                myPurchaseBtns[btnNo].gameObject.SetActive(false);
            }
          
            equipbtns[btnNo].gameObject.SetActive(true);

         
            CheckPurchaseable();


        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Loadcoins();
        }
    }


    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "Coins: " + shopItemsSO[i].itemPrice.ToString();
            
        }
    }

}
