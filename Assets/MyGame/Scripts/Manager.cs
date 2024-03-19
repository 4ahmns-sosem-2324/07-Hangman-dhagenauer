using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Linq;
using System;

public class Manager : MonoBehaviour
{

    // Legen Sie die Spieloberfl�che fest, einschlie�lich des R�tselbereichs, der Tastatur f�r Buchstaben, des Anzeigebereichs f�r bereits geratene Buchstaben und der Anzeige f�r den Galgenzustand.
    // Schritt 1:
    // Erstellen Sie eine Start Scene inder das Spiel gestartet werden kann.

    // Schritt 2: Wortliste und Auswahl eines zuf�lligen Worts
    // Erstellen Sie eine Liste von W�rtern f�r das Spiel.
    // Schreiben Sie Code, um ein zuf�lliges Wort aus der Liste auszuw�hlen und es im R�tselbereich anzuzeigen.

    // Schritt 3: Benutzereingaben und �berpr�fung
    // Zeichnen Sie ensprechende Platzhalter f�r das Geheimwort.
    // Implementieren Sie ein Inputfield, damit der Benutzer Buchstaben eingeben kann.
    // �berpr�fen Sie, ob der ausgew�hlte Buchstabe im geheimen Wort vorkommt.
    // Zeigen Sie den Buchstaben an wenn er korrekt war.
    // Aktualisieren Sie den Galgenzustand wenn der Buchstabe inkorrekt war.

    // Schritt 4: Galgenzustand und Endbedingungen
    // Zeichnen Sie den Galgen entsprechend dem Fortschritt des Benutzers.
    // Implementieren Sie die Logik f�r das Gewinnen oder Verlieren des Spiels basierend auf dem Galgenzustand (7 Zust�nde) und der Anzahl der falschen Buchstaben.
    // Geben Sie entsprechende Nachrichten aus, wenn das Spiel gewonnen oder verloren wurde.

    // Schritt 5: Benutzeroberfl�che
    // Entwerfen Sie eine benutzerfreundliche Oberfl�che, die das R�tsel, die Tastatur und den Galgen klar darstellt.
    // Implementieren Sie Benachrichtigungen und Feedback f�r den Benutzer, z.B. Nachrichten beim Gewinnen oder Verlieren.

    public Text wordDisplayText;
    public Text attemptsText;
    public Text guessedLettersText;

    private string[] words = {
        "Auto", "Flugzeug", "Schiff", "Zug", "Fahrrad",
        "Haus", "Wolke", "Sonne", "Mond", "Sterne",
        "Buch", "Stift", "Papier", "Tafel", "Schere",
        "Apfel", "Birne", "Pfirsich", "Melone", "Traube",
        "Kamera", "Handy", "Computer", "Fernseher", "Lautsprecher",
        "Fu�ball", "Basketball", "Tennisball", "Golfball", "Baseball",
        "Schule", "Universit�t", "Kindergarten", "Bibliothek", "Labor",
        "Brille", "Hut", "Schal", "Handschuhe", "Schuhe",
        "Tisch", "Stuhl", "Sofa", "Schrank", "Bett",
        "Rot", "Blau", "Gr�n", "Gelb", "Orange",
        "Winter", "Fr�hling", "Sommer", "Herbst", "Jahreszeiten",
        "Musik", "Film", "Buch", "Kunst", "Theater",
        "Pizza", "Burger", "Pasta", "Salat", "Suppe",
        "Kuchen", "Eis", "Schokolade", "Keks", "Bonbon",
        "Hundert", "Tausend", "Million", "Billion", "Trillion",
        "Feuer", "Wasser", "Erde", "Luft", "Elemente",
        "Familie", "Freunde", "Nachbarn", "Kollegen", "Bekannte",
        "Geschichte", "Geographie", "Biologie", "Physik", "Chemie",
        "Roboter", "Alien", "Mensch", "Tier", "Pflanze",
        "Zeit", "Raum", "Universum", "Galaxie", "Sonne",
        "Kunst", "Wissenschaft", "Sport", "Technologie", "Philosophie"
    }; // Hier k�nnen Sie Ihre eigenen W�rter hinzuf�gen
    private string secretWord;
    private char[] guessedLetters;
    private int attemptsLeft = 6;
    private string guessedLettersString = "";

    void Start()
    {
        // W�hle ein zuf�lliges Wort aus dem Array aus
        secretWord = words[UnityEngine.Random.Range(0, words.Length)].ToLower();
        Debug.Log(secretWord);
        // Initialisiere das Array f�r geratene Buchstaben
        guessedLetters = new char[secretWord.Length];
        Array.Fill(guessedLetters, '_');

        UpdateWordDisplay();
        UpdateAttemptsDisplay();
    }

    void Update()
    {
        if (attemptsLeft > 0 && !secretWord.Equals(new string(guessedLetters)))
        {
            if (Input.anyKeyDown)
            {
                char inputChar = Input.inputString.ToLower()[0];
                if (char.IsLetter(inputChar))
                {
                    CheckLetter(inputChar);
                }
            }
        }
    }

    void CheckLetter(char letter)
    {
        if (guessedLetters.Contains(letter))
        {
            Debug.Log("Letter already guessed: " + letter);
            return;
        }

        bool found = false;
        for (int i = 0; i < secretWord.Length; i++)
        {
            if (secretWord[i] == letter)
            {
                guessedLetters[i] = letter;
                found = true;
            }
        }

        if (!found)
        {
            attemptsLeft--;
            guessedLettersString += letter + " ";
            Debug.Log("Letter not found: " + letter);
        }

        UpdateWordDisplay();
        UpdateAttemptsDisplay();
        UpdateGuessedLettersDisplay();

        if (attemptsLeft == 0)
        {
            Debug.Log("Game Over!");
        }
        else if (secretWord.Equals(new string(guessedLetters)))
        {
            Debug.Log("You Win!");
        }
    }

    void UpdateWordDisplay()
    {
        string displayWord = "";
        foreach (char letter in guessedLetters)
        {
            displayWord += letter + " ";
        }
        wordDisplayText.text = displayWord;
    }

    void UpdateAttemptsDisplay()
    {
        attemptsText.text = "Attempts Left: " + attemptsLeft;
    }

    void UpdateGuessedLettersDisplay()
    {
        guessedLettersText.text = "Guessed Letters: " + guessedLettersString;
    }
}
