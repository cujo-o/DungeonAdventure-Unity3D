using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterCustomized : MonoBehaviour
{


    public const string DEFAULT_SAVE_JSON = "{\"s\":[{\"b\":0,\"i\":17},{\"b\":1,\"i\":27},{\"b\":2,\"i\":101},{\"b\":3,\"i\":159},{\"b\":4,\"i\":60},{\"b\":5,\"i\":34},{\"b\":6,\"i\":20},{\"b\":7,\"i\":25},{\"b\":8,\"i\":25},{\"b\":9,\"i\":12},{\"b\":10,\"i\":36}]}";



    public enum BodyPartType
    {
        Body,
        Hair,
        Eyes,
        Eyelashes,
        Underwear,
        Pants,
        Shoes,
        Gloves,
        Eyebrows,
        Mustache,
        Beard

    }


    [Serializable]
    public struct BodyPartTypeIndex
    {
        public BodyPartType bodyPartType;
        public int index;
    }

    [Serializable]
    public class Customization
    {

        public BodyPartTypeIndex[] bodyPartTypeIndexArray;


        public void ChangeIndex(CompleteBodyPartData completeBodyPartData, BodyPartType bodyPartType, int addAmount)
        {
            for (int i = 0; i < bodyPartTypeIndexArray.Length; i++)
            {
                if (bodyPartTypeIndexArray[i].bodyPartType == bodyPartType)
                {
                    BodyPartData bodyPartData = completeBodyPartData.GetBodyPartData(bodyPartType);
                    bodyPartTypeIndexArray[i].index = (bodyPartTypeIndexArray[i].index + addAmount) % bodyPartData.meshArray.Length;
                    if (bodyPartTypeIndexArray[i].index < 0) bodyPartTypeIndexArray[i].index += bodyPartData.meshArray.Length;
                }
            }
        }

        public void SetIndex(BodyPartType bodyPartType, int index)
        {
            for (int i = 0; i < bodyPartTypeIndexArray.Length; i++)
            {
                if (bodyPartTypeIndexArray[i].bodyPartType == bodyPartType)
                {
                    bodyPartTypeIndexArray[i].index = index;
                }
            }
        }

        public int GetIndex(BodyPartType bodyPartType)
        {
            for (int i = 0; i < bodyPartTypeIndexArray.Length; i++)
            {
                if (bodyPartTypeIndexArray[i].bodyPartType == bodyPartType)
                {
                    return bodyPartTypeIndexArray[i].index;
                }
            }
            return 0;
        }

        public void Randomize(CompleteBodyPartData completeBodyPartData)
        {
            foreach (BodyPartTypeIndex bodyPartTypeIndex in bodyPartTypeIndexArray)
            {
                int randomAdd = UnityEngine.Random.Range(0, +10000);
                ChangeIndex(completeBodyPartData, bodyPartTypeIndex.bodyPartType, randomAdd);
            }
        }

        public void Randomize(CompleteBodyPartData completeBodyPartData, BodyPartType bodyPartType)
        {
            foreach (BodyPartTypeIndex bodyPartTypeIndex in bodyPartTypeIndexArray)
            {
                if (bodyPartTypeIndex.bodyPartType == bodyPartType)
                {
                    int randomAdd = UnityEngine.Random.Range(0, +10000);
                    ChangeIndex(completeBodyPartData, bodyPartTypeIndex.bodyPartType, randomAdd);
                }
            }
        }






        [Serializable]
        public class SaveObject
        {

            [Serializable]
            public class Small
            {
                public BodyPartType b;
                public int i;
            }

            public Small[] s;
        }

        public SaveObject Save()
        {
            SaveObject.Small[] s = new SaveObject.Small[bodyPartTypeIndexArray.Length];
            for (int i = 0; i < bodyPartTypeIndexArray.Length; i++)
            {
                s[i] = new SaveObject.Small
                {
                    b = bodyPartTypeIndexArray[i].bodyPartType,
                    i = bodyPartTypeIndexArray[i].index,
                };
            }

            return new SaveObject
            {
                s = s,
            };
        }

        public static Customization LoadSpawn(string saveJson)
        {
            if (string.IsNullOrEmpty(saveJson))
            {
                saveJson = DEFAULT_SAVE_JSON;
            }
            return LoadSpawn(JsonUtility.FromJson<SaveObject>(saveJson));
        }

        public static Customization LoadSpawn(SaveObject saveObject)
        {
            Customization customization = new Customization();
            customization.Load(saveObject);
            return customization;
        }

        public void Load(SaveObject saveObject)
        {
            List<BodyPartTypeIndex> bodyPartTypeIndexList = new List<BodyPartTypeIndex>();
            foreach (SaveObject.Small small in saveObject.s)
            {
                bodyPartTypeIndexList.Add(new BodyPartTypeIndex
                {
                    bodyPartType = small.b,
                    index = small.i,
                });
            }
            bodyPartTypeIndexArray = bodyPartTypeIndexList.ToArray();
        }

    }




    [Serializable]
    public class BodyPartData
    {
        public BodyPartType bodyPartType;
        public Material[] meshArray;
        public SkinnedMeshRenderer skinnedMeshRenderer;

        public override string ToString()
        {
            return bodyPartType + "; " + meshArray.Length + "; " + skinnedMeshRenderer;
        }
    }

    [Serializable]
    public class CompleteBodyPartData
    {
        public BodyPartData[] bodyPartDataArray;

        public BodyPartData GetBodyPartData(BodyPartType bodyPartType)
        {
            foreach (BodyPartData bodyPartData in bodyPartDataArray)
            {
                if (bodyPartData.bodyPartType == bodyPartType)
                {
                    return bodyPartData;
                }
            }
            return null;
        }

        public void RefreshSkinnedMeshRenderer(Customization customization)
        {
            foreach (BodyPartData bodyPartData in bodyPartDataArray)
            {
                bodyPartData.skinnedMeshRenderer.material =
                    bodyPartData.meshArray[customization.GetIndex(bodyPartData.bodyPartType)];
            }
        }

        public int GetIndexMax(BodyPartType bodyPartType)
        {
            foreach (BodyPartData bodyPartData in bodyPartDataArray)
            {
                if (bodyPartData.bodyPartType == bodyPartType)
                {
                    return bodyPartData.meshArray.Length;
                }
            }
            return 0;
        }
    }





    public event EventHandler OnCustomizationChanged;


    [SerializeField] private CompleteBodyPartData completeBodyPartData;



    private Customization customization;


    private void Awake()
    {
        customization = GetDefaultCustomization();
    }

    private Customization GetDefaultCustomization()
    {
        /*
        Array bodyPartTypeArray = System.Enum.GetValues(typeof(BodyPartType));
        BodyPartTypeIndex[] bodyPartTypeIndexArray = new BodyPartTypeIndex[bodyPartTypeArray.Length];
        for (int i = 0; i < bodyPartTypeArray.Length; i++) {
            bodyPartTypeIndexArray[i].bodyPartType = (BodyPartType)bodyPartTypeArray.GetValue(i);
            bodyPartTypeIndexArray[i].index = 0;
        }

        return new Customization {
            bodyPartTypeIndexArray = bodyPartTypeIndexArray
        };*/

        return Customization.LoadSpawn("");
    }

    public void SetCustomization(Customization customization)
    {
        this.customization = customization;

        completeBodyPartData.RefreshSkinnedMeshRenderer(customization);

        OnCustomizationChanged?.Invoke(this, EventArgs.Empty);
    }

    public void Randomize()
    {
        customization.Randomize(completeBodyPartData);
        SetCustomization(customization);
    }

    public void Randomize(BodyPartType bodyPartType)
    {
        customization.Randomize(completeBodyPartData, bodyPartType);
        SetCustomization(customization);
    }

    public void ResetBodyPart(BodyPartType bodyPartType)
    {
        customization.SetIndex(bodyPartType, GetIndexMax(bodyPartType) - 1);
        SetCustomization(customization);
    }

    public void ChangeIndex(BodyPartType bodyPartType, int changeAmount)
    {
        customization.ChangeIndex(completeBodyPartData, bodyPartType, changeAmount);
        SetCustomization(customization);
    }

    public int GetIndex(BodyPartType bodyPartType)
    {
        return customization.GetIndex(bodyPartType);
    }

    public int GetIndexMax(BodyPartType bodyPartType)
    {
        return completeBodyPartData.GetIndexMax(bodyPartType);
    }

    public Customization.SaveObject Save()
    {
        return customization.Save();
    }

    public void LoadDefaultCharacter()
    {
        SetCustomization(GetDefaultCustomization());
    }

    public void Load(string saveObjectJson)
    {
        if (string.IsNullOrEmpty(saveObjectJson))
        {
            SetCustomization(GetDefaultCustomization());
            return;
        }
        Load(
            JsonUtility.FromJson<Customization.SaveObject>(saveObjectJson)
        );
    }

    public void Load(Customization.SaveObject saveObject)
    {
        customization.Load(saveObject);
        SetCustomization(customization);
    }

}