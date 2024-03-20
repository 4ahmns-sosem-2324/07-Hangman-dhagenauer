# 07-Hangman-dhagenauer
![image](https://github.com/DaveHagenauer/07-Hangman-dhagenauer/assets/127969496/42a51ec3-6d39-40f8-8f8e-949cc9c1659d)
 // Legen Sie die Spieloberfläche fest, einschließlich des Rätselbereichs, der Tastatur für Buchstaben, des Anzeigebereichs für bereits geratene Buchstaben und der Anzeige für den Galgenzustand.
 // Schritt 1:
 // Erstellen Sie eine Start Scene inder das Spiel gestartet werden kann.

 // Schritt 2: Wortliste und Auswahl eines zufälligen Worts
 // Erstellen Sie eine Liste von Wörtern für das Spiel.
 // Schreiben Sie Code, um ein zufälliges Wort aus der Liste auszuwählen und es im Rätselbereich anzuzeigen.

 // Schritt 3: Benutzereingaben und Überprüfung
 // Zeichnen Sie ensprechende Platzhalter für das Geheimwort.
 // Geben Sie dem Nutzer die Möglichkeit Buchstaben einzugeben.
 // Überprüfen Sie, ob der ausgewählte Buchstabe im geheimen Wort vorkommt.
 // Zeigen Sie den Buchstaben an wenn er korrekt war.
 // Aktualisieren Sie den Galgenzustand wenn der Buchstabe inkorrekt war.

 // Schritt 4: Galgenzustand und Endbedingungen
 // Zeichnen Sie den Galgen entsprechend dem Fortschritt des Benutzers.
 // Implementieren Sie die Logik für das Gewinnen oder Verlieren des Spiels basierend auf dem Galgenzustand (5 Zustände) und der Anzahl der falschen Buchstaben.
 // Geben Sie entsprechende Nachrichten aus, wenn das Spiel gewonnen oder verloren wurde.

 // Schritt 5: Benutzeroberfläche
 // Entwerfen Sie eine benutzerfreundliche Oberfläche, die das Rätsel, die Tastatur und den Galgen klar darstellt.
 // Implementieren Sie Benachrichtigungen und Feedback für den Benutzer, z.B. Nachrichten beim Gewinnen oder Verlieren.
```mermaid
classDiagram
    MonoBehaviour <|-- Manager
    MonoBehaviour <|-- StartManager
   
    
     class Manager {
        + wordDisplayText: Text
        + attemptsText: Text
        + guessedLettersText: Text
        + win: int
        - words: string[]
        - secretWord: string
        - guessedLetters: char[]
        - attemptsLeft: int
        - guessedLettersString: string
        + hangman: GameObject[]
        - Start() void
        - Update() void
        - CheckLetter(char letter) void
        - UpdateWordDisplay() void
        - UpdateAttemptsDisplay() void
        - UpdateGuessedLettersDisplay() void
    }
class StartManager {
        + win: int
        + winText: Text
        - Start() void
        - Update() void
        + StartButton() void
    }
    ```
