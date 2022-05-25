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
    [Tooltip("The randomly chosen word")]
    [SerializeField] private string _chosenWord;
    [Tooltip("Text component that will display the hidden word to the screen")]
    [Header("Text Components")]
    [SerializeField] private Text wordDisplayText;

    private List<char> _chosenWordsLetters;
    #endregion
    #region Properties
    public string ChosenWord { get => _chosenWord; }
    public List<char> HiddenWordLengthList { get => _hiddenWordList; set => value = _hiddenWordList; }
    public List<char> ChosenWordLetters { get => _chosenWordsLetters; }
    #endregion

    void Start()
    {
        SelectRandomWord(_wordsList);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SelectRandomWord(_wordsList);
        }
    }

    private void SelectRandomWord(List<string> stringList) //selects a random element from the input list of strings
    {
        int randomNum = Random.Range(0, stringList.Count); //rolls a number between 0 and the input list count
        foreach (string item in _wordsList)
        {
            if (item == stringList[randomNum]) //if element in list matches randomNum
            {
                _chosenWord = stringList[randomNum]; //chosenWord value is input string list at element of randomNum
            }
        }
        _chosenWordsLetters = _chosenWord.ToList(); //fills chosenWordsLetters char list from chosenWord string
        CreateHiddenWord(); //runs CreateHiddenWord function
    }

    private void CreateHiddenWord()
    {
        if (_hiddenWordList.Count > 0) //if the hiddenWordList already has elements in it
        {
            _hiddenWordList.Clear(); //clear the list
        }
        foreach (char letter in _chosenWordsLetters) //for every char in chosenWordLetters
        {
            _hiddenWordList.Add('_'); //add an element with '_' to hiddenWordsList
        }
        string word = new string(_hiddenWordList.ToArray()); //creates a string out of hiddenWordList char
        for (int i = 0; i < word.Length; i++) //for every char in word
        {
            word = word.Insert(i, " "); //add " " after each char
            i++;
        }
        wordDisplayText.text = word;
    }
}
