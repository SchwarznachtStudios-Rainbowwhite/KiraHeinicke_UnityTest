using UnityEngine;
using System.Collections.Generic;


public class XMasGame : MonoBehaviour{

// VARIABLES VARIABLES VARIABLES

    public GameObject Sleigh;
    public GameObject SantaGo;

    public int Presents = 4;
    public int SantaHealth = 100;
    private float _flyingSpeed = 10f;

    public List<string> GiftInventory = new List<string>();
    public string Winning;

    private bool _isFlying; 
    
    


// START START START

    void Start() 
    {
        Debug.Log("Weihnachtsabenteuer beginnt!");

        //Zurücksetzen SantaHealth
        SantaHealth = 100;

        //FindingCalls
        SantaGo = GameObject.Find("Santa");
        Sleigh = GameObject.Find("Sleigh");

    }

// UPDATE UPDATE UPDATE UPDATE
    void Update() 
    { 
        CheckforGameEnd();

    } 

// FUNCTIONS FUNCTIONS FUNCTIONS 
    
    void CheckMovement()
    {
        // Wenn _isFlying == true
        // Bewegung des Schlittens, sonst Fehlermeldung
        if (_isFlying)
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Sleigh.transform.Translate(move * _flyingSpeed * Time.deltaTime);
        }
        else 
        {
            Debug.Log("Santa kann nicht fliegen!"); 
        } 
    }
    
    
    void CheckInventory()
    {
        // Wenn keine Geschenke vorhanden, Fehlermeldung
        // Wenn Geschenkt vorhanden, Ausgabe dieser über jeweiligen Namen
        if (GiftInventory.Count == 0) 
        { 
            Debug.Log("Keine Geschenke vorhanden.");
        } 
        else 
        { 
            foreach (var gift in GiftInventory) 
            { 
                Debug.Log("Geschenk im Inventar: " + gift); 
            } 
        }
    }

    public void TakeDamage(int damage) 
    { 
        // Schaden von Santas Health abziehen
        SantaHealth -= damage; 
        
        // Wenn Santas Health unter 0 fällt, setzen auf 0
        if (SantaHealth < 0) 
        { 
            SantaHealth = 0; 
        } 
    }

    public void AddGiftToInventory(string gift) 
    { 
        // Wenn Geschenk noch nicht im Inventar vorhanden, füge dieses diesem hinzu
        if (!GiftInventory.Contains(gift)) 
        { 
            GiftInventory.Add(gift); 
        } 
    }  
    
    // Fliegen Start
    public void StartFlying() 
    { 
        _isFlying = true; 
    }

    // Stoppt Fliegen
    public void StopFlying() 
    { 
        _isFlying = false; 
    }

    public void CheckforGameEnd()
    {
        // Wenn Santas Health über 0 ist, Überprüfung des Inventars und des Movements
        // Wenn 0, dann ist "Weihnachten vorbei" = Game Ende
        if (SantaHealth > 0)
        {
            CheckMovement();
            CheckInventory();
        }
        else
        {
            Debug.Log("Weihnachten ist vorbei!");
        }

    }

}
