using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class NumberFilter : MonoBehaviour
{

// VARIABLES VARIABLES

    public int[] Numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public int[] EvenNumbers;
    public int[] OddNumbers;

    private int _counterEven = 0;
    private int _counterOdd = 0;

    // START

    public void Start()
    {
        SortList();

        WriteEvenNumbers();
        WriteOddNumbers();
    }

    // FUNCTIONS FUNCTIONS

    public void SortList()
    {
        foreach (int number in Numbers)
        {
            // Wenn Zahl Gerade, zu even numbers
            // _counterEven nach jeder hinzugefügten Zahl hochgezählt, um jeweils einen nächsten Platz im Array zu besetzen
            if (number % 2 == 0)
            {          
                EvenNumbers[_counterEven] = number;
                _counterEven++;
            }
            // Wenn Zahl Ungerade, zu odd numbers
            // _counterOdd nach jeder hinzugefügten Zahl hochgezählt, um jeweils einen nächsten Platz im Array zu besetzen
            else if (number % 2 == 1)
            {
                OddNumbers[_counterOdd] = number;
                _counterOdd++;
            }

           
        }

    }

    public void WriteEvenNumbers()
    {
        // Zählt durch das Array durch und gibt einzeln jede Nummer aus
        for (int i = 0; i < EvenNumbers.Length; i++)
        {
            Debug.Log("EvenNumber: " + EvenNumbers[i]);
        }

    }

    public void WriteOddNumbers()
    {
        // Zählt durch das Array durch und gibt einzeln jede Nummer aus
        for (int i = 0; i < OddNumbers.Length; i++)
        {
            Debug.Log("OddNumber: " + OddNumbers[i]);
        }

    }
}
