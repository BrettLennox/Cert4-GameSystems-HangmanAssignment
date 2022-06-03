using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessManager : MonoBehaviour
{
    #region Variables
    [Header("Images for Guesses")]
    [SerializeField] private List<Sprite> _hangmanSprites;
    [SerializeField] private Image _displayImage;
    [Header("Misc data")]
    [Tooltip("Input field component users will enter text into")]
    [SerializeField] private InputField _inputField;
    [Tooltip("Text component in PostGameUI")]
    [SerializeField] private Text _gameOverStateText;

    private int _incorrectGuessCount = 0;
    private int _correctGuessCount = 0;
    private bool _isCorrectGuess;
    private char letter;
    private WordSelector _ws;
    private StateMachine _sm;
    #endregion
    private void Awake()
    {
        _ws = GetComponent<WordSelector>();
        _sm = GetComponent<StateMachine>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (_sm.GameState == StateMachine.GameStates.Game)
        {
            if (_incorrectGuessCount >= 5) //if incorrectGuessCount is greater then or equal to 5 && GameState is set to Game
            {
                GameOver("You Lose"); //runs GameOver function with passed in string
            }
            else if (_correctGuessCount == _ws.ChosenWord.Length) //else if correctGuessCount equals ChosenWord length && GameState is set to Game
            {
                GameOver("You Win"); //runs GameOver function with passed in string
            }
        }
    }

    private void GameOver(string gameOverText)
    {
        _gameOverStateText.text = gameOverText; //sets gameOverStateText text to the passed in gameOverText string
        _sm.GameState = StateMachine.GameStates.PostGame; //sets GameState to PostGame
    }

    public void ResetGame() //resets values for the game
    {
        _incorrectGuessCount = 0;
        _correctGuessCount = 0;
        _isCorrectGuess = false;
        UpdateImageDisplay(); //runs UpdateImageDisplay function
    }

    public void SendLetter()
    {
        if (_inputField.text.Length >= _inputField.characterLimit)
        {
            letter = char.Parse(_inputField.text); //creates letter variable from the text value parsed from inputField
            letter = char.ToUpper(letter); //converts letter to uppercase
            CheckLetter(letter); //runs CheckLetter function with letter parsed in
            _inputField.text = null; //clears inputField text
        }
    }

    private void CheckLetter(char guessLetter)
    {
        for (int i = 0; i < _ws.ChosenWordLetters.Count; i++) //for every char in ChosenWordLetters
        {
            if (_ws.ChosenWordLetters[i] == guessLetter) //if ChosenWordLetter at count i is equal to guessLetter parsed in
            {
                _ws.HiddenWordList[i] = guessLetter; //HiddenWordList at count i equals guessLetter parsed in
                _isCorrectGuess = true; //sets isCorrectGuess to true
            }
        }
        if (!_isCorrectGuess) //if after the loop is complete isCorrectGuess is set to false
        {
            _incorrectGuessCount++; //increment incorrectGuessCount
            UpdateImageDisplay(); //runs updateImageDisplay function
        }
        else
        {
            _correctGuessCount++;
        }
        _isCorrectGuess = false; //sets isCorrectGuess to false so the forloop can update it if needed
        _ws.CreateHiddenWordValues(); //runs CreateHiddenWordValues function to update the displayed results values
    }

    private void ResetSprites()
    {
        _incorrectGuessCount = 0; //sets incorrectGuessCount back to 0
    }

    private void UpdateImageDisplay()
    {
        _displayImage.sprite = _hangmanSprites[_incorrectGuessCount]; //displayImage sprite is set to hangmanSprites at index of incorrectGuessCount
    }
}
