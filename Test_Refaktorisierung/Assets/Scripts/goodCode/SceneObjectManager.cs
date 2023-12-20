using UnityEngine;
using System.Collections.Generic;

public class SceneObjectManager : MonoBehaviour
{

// VARIABLES VARIABLES
    public GameObject[] Enemies;
    public GameObject[] Items;


    public string[] EnemyTypes = { "fire", "water", "ice", "stone" };
    

    Dictionary<GameObject, string> DictionaryEnemies = new Dictionary<GameObject, string>();
    Dictionary<GameObject, Vector3> DictionaryItems = new Dictionary<GameObject, Vector3>();

// START START

    public void Start()
    {

        SortByTag();
        EnemyType();
        //ItemPosition();

        WriteEnemyAndType();
        //WriteItemAndPosition();
    }

// FUNCTIONS FUNCTIONS

    public void SortByTag()
    {
        // Sucht alle GameObjects mit entsprechendem Tag in der Szene und fügt sie dem jweiligen Array hinzu
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Items = GameObject.FindGameObjectsWithTag("Item");

    }

    public void EnemyType()
    {
        // Jedes Enemy Object wird dem Dictionary zugeordnet, sowie jedem ein zufälliger Typ aus enemyTypes
        for (int i = 0; i < Enemies.Length; i++)
        {
            DictionaryEnemies.Add(Enemies[i], EnemyTypes[Random.Range(0,EnemyTypes.Length)]);

        }
    }

    /*public void ItemPosition()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            DictionaryItems.Add(Enemies[i], new Vector3(Random.Range(0, 10f), Random.Range(0, 10f), Random.Range(0, 10f)));
            //RandomRange Position gibt noch out of bounds error
        }

    }*/

    public void WriteEnemyAndType()
    {
        // Zählt durch das Dictionary durch und gibt Enemy mit zugehörigem Typ aus
        foreach (KeyValuePair<GameObject, string> items in DictionaryEnemies)
        {
            print("Enemy: " + items.Key + " of Type: " + items.Value);

        }

    }

    public void WriteItemAndPosition()
    {
        // Zählt durch das Dictionary durch und gibt Item mit zugehöriger Position aus
        foreach (KeyValuePair<GameObject, Vector3> items in DictionaryItems)
        {
            print("Item: " + items.Key + " at Position: " + items.Value);

        }

    }
}
