using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreatorUI_BodyPartSingle : MonoBehaviour
{


    [SerializeField] private PlayerCharacterCustomized playerCharacterCustomized;
    [SerializeField] private PlayerCharacterCustomized.BodyPartType bodyPartType;
    [SerializeField] private TextMeshProUGUI amountTextMesh;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private Button randomButton;


    private void Awake()
    {
        nextButton.onClick.AddListener(() => {
            playerCharacterCustomized.ChangeIndex(bodyPartType, +1);
            Debug.Log("nextButton");
        });
        previousButton.onClick.AddListener(() => {
            playerCharacterCustomized.ChangeIndex(bodyPartType, -1);
        });
        resetButton.onClick.AddListener(() => {
            playerCharacterCustomized.ResetBodyPart(bodyPartType);
        });
        randomButton.onClick.AddListener(() => {
            playerCharacterCustomized.Randomize(bodyPartType);
        });
    }

    private void Start()
    {
        playerCharacterCustomized.OnCustomizationChanged += PlayerCharacterCustomized_OnCustomizationChanged;

        UpdateVisual();
    }

    private void PlayerCharacterCustomized_OnCustomizationChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        amountTextMesh.text =
            "(" + playerCharacterCustomized.GetIndex(bodyPartType) + "/" +
            (playerCharacterCustomized.GetIndexMax(bodyPartType) - 1) + ")";
    }

}