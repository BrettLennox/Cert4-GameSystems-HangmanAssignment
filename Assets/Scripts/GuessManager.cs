using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessManager : MonoBehaviour
{
    [SerializeField] private InputField _inputField;
    private char letter;

    public void SendLetter()
    {
        letter = char.Parse(_inputField.text);
        Debug.Log(letter);
        _inputField.text = null;
    }
}
