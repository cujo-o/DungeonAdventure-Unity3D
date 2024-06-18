
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreatorUI : MonoBehaviour
{


    private const string PLAYER_PREFS_KEY = "PlayerCustomization";


    [SerializeField] private PlayerCharacterCustomized playerCharacterCustomized;
    [SerializeField] private Button randomizeButton;
    [SerializeField] private Button saveCharacterButton;
    [SerializeField] private Button rotateRightButton;
    [SerializeField] private Button rotateLeftButton;
    [SerializeField] private Button backButton;



    private Vector3 playerTargetForward;


    private void Awake()
    {
        randomizeButton.onClick.AddListener(() => {
            playerCharacterCustomized.Randomize();
        });
        saveCharacterButton.onClick.AddListener(() => {
            string characterJson = JsonUtility.ToJson(playerCharacterCustomized.Save());
            PlayerPrefs.SetString(PLAYER_PREFS_KEY, characterJson);
            Debug.Log("Saving Character: " + characterJson);
        });
       

        playerTargetForward = playerCharacterCustomized.transform.forward;
    }

    private void Start()
    {
        /*  if (string.IsNullOrEmpty(PlayerPrefs.GetString(PLAYER_PREFS_KEY, "")))
          {
              // Never made a character
              playerCharacterCustomized.Randomize();
              FunctionTimer.Create(playerCharacterCustomized.Randomize, .100f);
              FunctionTimer.Create(playerCharacterCustomized.Randomize, .200f);
              FunctionTimer.Create(playerCharacterCustomized.Randomize, .300f);
              FunctionTimer.Create(playerCharacterCustomized.Randomize, .400f);
              FunctionTimer.Create(playerCharacterCustomized.Randomize, .500f);
              FunctionTimer.Create(playerCharacterCustomized.Randomize, .600f);
              FunctionTimer.Create(playerCharacterCustomized.Randomize, .700f);
              FunctionTimer.Create(playerCharacterCustomized.Randomize, .800f);
              FunctionTimer.Create(playerCharacterCustomized.Randomize, .900f);
              FunctionTimer.Create(playerCharacterCustomized.Randomize, .999f);
              FunctionTimer.Create(playerCharacterCustomized.LoadDefaultCharacter, .999f);
          }
          else
          {
              // Has a saved character

          }*/
        playerCharacterCustomized.Load(PlayerPrefs.GetString(PLAYER_PREFS_KEY, ""));
    }

    private void Update()
    {
        float rotateSpeed = 6f;
        playerCharacterCustomized.transform.forward = Vector3.Slerp(
            playerCharacterCustomized.transform.forward,
            playerTargetForward,
            Time.deltaTime * rotateSpeed
        );
    }

}