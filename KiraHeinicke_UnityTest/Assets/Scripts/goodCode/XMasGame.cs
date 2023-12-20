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
        SantaHealth -= damage; 
        
        if (SantaHealth < 0) 
        { 
            SantaHealth = 0; 
        } 
    }

    public void AddGiftToInventory(string gift) 
    { 
        if (!GiftInventory.Contains(gift)) 
        { 
            GiftInventory.Add(gift); 
        } 
    }  
    
    public void StartFlying() 
    { 
        _isFlying = true; 
    }

    public void StopFlying() 
    { 
        _isFlying = false; 
    }

    public void CheckforGameEnd()
    {
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
