using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class GetJsonSprites : MonoBehaviour
{
    Dictionary<string, string> translation;

    void Awake()
    {
        //loading json file
        var textFile = Resources.Load<TextAsset>("Sprites");
        //loading json file as a dictionary to easily convert names into paths
        translation = JsonConvert.DeserializeObject<Dictionary<string, string>>(textFile.text);
    }

    //Translating item name into its sprite
    public Sprite GetSprite(string id)
    {
        string path = translation[id];
        //loading sprite at given path
        Sprite sprite = Resources.Load<Sprite>(path);
        return sprite;
    }
}
