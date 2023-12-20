using UnityEngine;
using System.Collections.Generic;

public class ItemCollector : MonoBehaviour
{

// VARIABLES VARIABLES

    public GameObject[] Items = new GameObject[5];

    private int _itemCounter = 0;


// START START START

    public void Start()
    {
        _itemCounter = 0;
    }

// UPDATE UPDATE UPDATE

    void Update()
    {
        CollectItems();
    }

// FUNCTIONS FUNCTIONS 

    void CollectItems()
    {
        // Durchzählen des Item Arrays
        foreach(GameObject item in Items)
        {
            // Item wird im Item Array an der Stelle des itemCounters eingespeichert
            Items[_itemCounter] = item;

            // Hochzählen des itemCounters um Überschreibungen zu vermeiden
            _itemCounter++;

            // Wenn Maximale Menge an Items (Item Array Länge = Inventar Größe? ) erreicht ist, Fehlermeldung
            if (_itemCounter == Items.Length)
            {
                Debug.Log("Inventar voll");
            }
        }

    }
}
