using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessManager : MonoBehaviour
{
    [SerializeField] private InputField _inputField;
    [SerializeField] private Text _remainingGuessesText;
    [SerializeField] private int _remainingGuesses = 6;
    private char letter;
    private WordSelector _ws;

    private void Awake()
    {
        _ws = GetComponent<WordSelector>();
    }

    private void Start()
    {
        _remainingGuesses = 6;
        _remainingGuessesText.text = "Guesses Remaining: " + _remainingGuesses;
    }

    public void SendLetter()
    {
        letter = char.Parse(_inputField.text); //creates letter variable from the text value parsed from inputField
        letter = char.ToUpper(letter); //converts letter to uppercase
        CheckLetter(letter); //runs CheckLetter function with letter parsed in
        _inputField.text = null; //clears inputField text
    }

    private void CheckLetter(char guessLetter)
    {
        for(int i = 0; i < _ws.ChosenWordLetters.Count; i++) //for every char in ChosenWordLetters
        {
            if(_ws.ChosenWordLetters[i] == guessLetter) //if ChosenWordLetter at count i is equal to guessLetter parsed in
            {
                _ws.HiddenWordList[i] = guessLetter; //HiddenWordList at count i equals guessLetter parsed in
            }
        }
        _ws.CreateHiddenWordValues(); //runs CreateHiddenWordValues function to update the displayed results values
    }
}
