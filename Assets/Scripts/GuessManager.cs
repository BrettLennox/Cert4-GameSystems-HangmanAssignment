using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessManager : MonoBehaviour
{
    [SerializeField] private Text _wordDisplayText;

    private WordSelector _ws => GetComponent<WordSelector>();

    private void Start()
    {
        
    }
}
