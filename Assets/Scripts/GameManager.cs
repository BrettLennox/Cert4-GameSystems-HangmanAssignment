using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PauseFunctionUIs _pauseFunctionUI;

    [System.Serializable]
    private struct PauseFunctionUIs
    {
        public GameObject _pauseUI;
        public GameObject _gameScreenUI;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_pauseFunctionUI._pauseUI.activeInHierarchy) //if escape is pressed and PauseUI is not active in heirarchy
        {
            _pauseFunctionUI._pauseUI.SetActive(true);
            _pauseFunctionUI._gameScreenUI.SetActive(false);
        }
    }
}

