using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScreenUI;
    [SerializeField] private GameObject _gameScreenUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_pauseScreenUI.activeInHierarchy) //if escape is pressed and PauseUI is not active in heirarchy
        {
            _pauseScreenUI.SetActive(true);
            _gameScreenUI.SetActive(false);
        }
    }
}

