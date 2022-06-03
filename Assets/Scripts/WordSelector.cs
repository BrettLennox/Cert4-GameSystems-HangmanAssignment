using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WordSelector : MonoBehaviour
{
    #region Variables
    [Tooltip("Selection of words to be chosen from")]
    [SerializeField] private List<string> _wordsList = new List<string>();
    [Tooltip("The list of chars that will be passed on to display")]
    [SerializeField] private List<char> _hiddenWordList;
    [Tooltip("Text component that will display the hidden word to the screen")]
    [Header("Text Components")]
    [SerializeField] private Text _wordDisplayText;
    
    private List<char> _chosenWordsLetters;
    private string _chosenWord;
    #endregion
    #region Properties
    public string ChosenWord { get => _chosenWord; }
    public List<char> HiddenWordList { get => _hiddenWordList; set => _hiddenWordList = value; }
    public List<char> ChosenWordLetters { get => _chosenWordsLetters; }
    public Text WordDisplayText { get => _wordDisplayText; set => _wordDisplayText = value; }
    #endregion

    public void SelectRandomWord() //selects a random element from the input list of strings
    {
        int randomNum = Random.Range(0, _wordsList.Count); //rolls a number between 0 and the input list count
        foreach (string item in _wordsList)
        {
            if (item == _wordsList[randomNum]) //if element in list matches randomNum
            {
                _chosenWord = _wordsList[randomNum]; //chosenWord value is input string list at element of randomNum
            }
        }
        _chosenWordsLetters = ChosenWord.ToList(); //fills chosenWordsLetters char list from chosenWord string
        for(int i = 0; i< _chosenWordsLetters.Count; i++) //for every char in chosenWordLetters
        {
            ChosenWordLetters[i] = char.ToUpper(ChosenWordLetters[i]); //converts the chars value to uppercase
        }
        CreateHiddenWord(); //runs CreateHiddenWord function
    }

    private void CreateHiddenWord()
    {
        if (_hiddenWordList.Count > 0) //if the hiddenWordList already has elements in it
        {
            _hiddenWordList.Clear(); //clear the list
        }
        foreach (char letter in ChosenWordLetters) //for every char in chosenWordLetters
        {
            _hiddenWordList.Add('_'); //add an element with '_' to hiddenWordsList
        }
        CreateHiddenWordValues();
    }

    public void CreateHiddenWordValues()
    {
        string word = new string(_hiddenWordList.ToArray()); //creates a string out of hiddenWordList char
        for (int i = 0; i < word.Length; i++) //for every char in word
        {
            word = word.Insert(i, " "); //add " " after each char
            i++;//increment i
        }
        _wordDisplayText.text = word;//updates wordDisplayText to be word
    }
}
