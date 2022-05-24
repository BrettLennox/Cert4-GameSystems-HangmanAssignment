using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordSelector : MonoBehaviour
{
    #region Variables
    [SerializeField] private List<string> _wordsList = new List<string>();
    [SerializeField] private string _chosenWord;
    [SerializeField] private List<char> _chosenWordsLetters;
    #endregion
    #region Properties
    public string ChosenWord { get => _chosenWord; }
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

    private void SelectRandomWord(List<string> stringList)
    {
        int randomNum = Random.Range(0, stringList.Count);
        foreach (string item in _wordsList)
        {
            if (item == stringList[randomNum])
            {
                _chosenWord = stringList[randomNum];
            }
        }
        _chosenWordsLetters = _chosenWord.ToList();
    }
}
