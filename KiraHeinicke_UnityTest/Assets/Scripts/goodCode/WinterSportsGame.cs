using UnityEngine;
using System.Collections.Generic;

public class WinterSportsGame : MonoBehaviour
{

    // VARIABLES VARIABLES

    public GameObject Ski;

    public int PlayerStamina = 100;
    public float PlayerSpeed = 10f;

    public List<string> Achievements = new List<string>();

    private bool _isSkiing;


// START START START
    void Start()
    { 
        // Zurücksetzen Stamina
        PlayerStamina = 100; 


        Debug.Log("WinterSports beginnt!");
    }

// UPDATE UPDATE UPDATE
    void Update() 
    {
        // Überprüfen ob Spiel zuende
        CheckForGameEnd();

    }


// FUNCTIONS FUNCTIONS

    void CheckSkiing()
    { 
        // Wenn Skiing, dann Bewegung
        // Sonst Fehlermeldung
        if (_isSkiing) 
        { 
            var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Ski.transform.Translate(move * PlayerSpeed * Time.deltaTime); 
        }
        else
        { 
            Debug.Log("Spieler kann nicht Ski fahren!");
        } 
    }


    void CheckAchievements()
    {
        // Prüfung ob Achievements erreicht worden.
        // Meldung wenn keine, ansonsten Auflistung der Achievements
        if (Achievements.Count == 0) 
        { 
            Debug.Log("Keine Erfolge erzielt."); 
        } 
        else
        { 
            foreach (var achievement in Achievements) 
            { 
                Debug.Log("Erfolg: " + achievement);
            }
        }
    }


    // Händelt den Ausdauerverlust des Spielers
    public void LoseStamina(int amount)
    {

        PlayerStamina -= amount;

        // Wenn Stamina unter 0 ist, auf 0 setzen
        if (PlayerStamina < 0) 
        {
            PlayerStamina = 0;
        }
    }

    public void AddAchievement(string achievement) 
    { 
        // Wenn Achievement nicht in Liste, dann hinzufügen
        if (!Achievements.Contains(achievement))
        { 
            Achievements.Add(achievement); 
        }
    }

    public void StartSkiing()
    {
        _isSkiing = true;
    }

    public void StopSkiing()
    { 
        _isSkiing = false;
    }

    public void CheckForGameEnd()
    {
        // Wenn Ausdauer über 0, Soiel läuft
        // Ansonsten Spiel zuende
        if (PlayerStamina > 0)
        {
            CheckSkiing();
            CheckAchievements();
        }
        else
        {
            Debug.Log("Spiel beendet!");
        }

    }

}
