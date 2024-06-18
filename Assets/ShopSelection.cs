using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSelection : MonoBehaviour
{
    [Header("Navigation Buttons")]
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    [Header("Play/Buy Buttons")]
    [SerializeField] private Button[] play;
    [SerializeField] private Button buy;
    [SerializeField] private TextMeshProUGUI priceText;

    [Header("Car Attributes")]
    [SerializeField] private int[] carPrices;
    private int currentCar;

   // [Header("Sound")]
   // [SerializeField] private AudioClip purchase;
  //  private AudioSource source;

    private void Start()
    {
      //  source = GetComponent<AudioSource>();
        currentCar = ShopSaveManager.instance.currentCarr;
        SelectCar(currentCar);
    }

    private void SelectCar(int _index)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == _index);

        UpdateUI();
    }
    private void UpdateUI()
    {
        //If current car unlocked show the play button
        if (ShopSaveManager.instance.carsUnlocked[currentCar])
        {
            play[currentCar].gameObject.SetActive(true);
            buy.gameObject.SetActive(false);
        }
        //If not show the buy button and set the price
        else
        {
            play[currentCar].gameObject.SetActive(false);
            buy.gameObject.SetActive(true);
            priceText.text = carPrices[currentCar] + "$";
        }
    }

    private void Update()
    {
        //Check if we have enough money
        if (buy.gameObject.activeInHierarchy)
            buy.interactable = (ShopSaveManager.instance.money >= carPrices[currentCar]);
    }

    public void ChangeCar(int _change)
    {
        currentCar += _change;

        if (currentCar > transform.childCount - 1)
            currentCar = 0;
        else if (currentCar < 0)
            currentCar = transform.childCount - 1;

        ShopSaveManager.instance.currentCarr = currentCar;
        ShopSaveManager.instance.Save();
        SelectCar(currentCar);
    }
    public void BuyCar()
    {
        ShopSaveManager.instance.money -= carPrices[currentCar];
        ShopSaveManager.instance.carsUnlocked[currentCar] = true;
        ShopSaveManager.instance.Save();
      //  source.PlayOneShot(purchase);
        UpdateUI();
    }
}