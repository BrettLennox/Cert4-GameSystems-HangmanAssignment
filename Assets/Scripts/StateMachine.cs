using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    #region Variables
    [Tooltip("The UI panels displayed in the game")]
    [SerializeField] private List<GameObject> panels;

    private GameStates _gameState;
    #endregion
    #region Properties
    public GameStates GameState { get => _gameState; set => _gameState = value; }
    #endregion
    private void Awake()
    {
        _gameState = GameStates.Menu; //sets the gameState to the Menu state on awake
    }

    private void Start()
    {
        NextState(); //runs NextState function
    }

    private void NextState()
    {
        switch (_gameState) 
        {
            case GameStates.Menu: //if gameState is set to Menu
                StartCoroutine(MenuRoutine()); //starts MenuRoutine coroutine
                break;
            case GameStates.Game: //if gameState is set to Game
                StartCoroutine(GameRoutine()); //starts GameRoutine coroutine
                break;
            case GameStates.Pause: //if gameState is set to Pause
                StartCoroutine(PauseRoutine()); //starts PauseRoutine coroutine
                break;
            case GameStates.PostGame: //if gameState is set to PostGame
                StartCoroutine(PostGameRoutine()); //starts PostGameRoutine coroutine
                break;
        }
    }

    private IEnumerator MenuRoutine()
    {
        while (_gameState == GameStates.Menu) //while gameState is set to Menu
        {
            SetPanels(0); //runs SetPanels function with int index 0 parsed in
            yield return null;
        }
        NextState(); //runs NextState function
    }

    private IEnumerator GameRoutine()
    {
        while (_gameState == GameStates.Game) //while gameState is set to Game
        {
            SetPanels(1); //runs SetPanels function with int index 1 parsed in
            if (Input.GetKeyDown(KeyCode.Escape)) //if user inputs Escape key
            {
                _gameState = GameStates.Pause; //sets gameState to Pause
            }
            yield return null;
        }
        NextState(); //runs NextState function
    }

    private IEnumerator PauseRoutine()
    {
        while (_gameState == GameStates.Pause) //while gameState is set to Pause
        {
            SetPanels(2); //runs SetPanels function with int index 2 parsed in
            yield return null;
        }
        NextState(); //runs NextState function
    }

    private IEnumerator PostGameRoutine()
    {
        while (_gameState == GameStates.PostGame) //while gameState is set to PostGame
        {
            SetPanels(3); //runs SetPanels function with int index 3 parsed in
            yield return null;
        }
        NextState(); //runs NextState function
    }

    private void SetPanels(int index)
    {
        for (int i = 0; i < panels.Count; i++) //loops through for the length of the panels count
        {
            if (i == index) //if i == passed in int named index
            {
                panels[i].SetActive(true); //panels at index i are set active
            }
            else //else
            {
                panels[i].SetActive(false); //sets inactive any panels that do not match the passed in index int
            }
        }
    }

    public void StartGameButton() //button function for StartGame //sets gameState to Game
    {
        _gameState = GameStates.Game;
    }

    public void ResumeGameButton() //button function for ResumeGame //sets gameState to Game
    {
        _gameState = GameStates.Game;
    }

    public void ReturnToMenuButton() //button function for ReturnToMenu //sets gameState to Menu
    {
        _gameState = GameStates.Menu;
    }

    public void QuitGameButton() //button function for QuitGame //exits application or sets isPlaying to false if in UnityEditor
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


    public enum GameStates
    {
        Menu,
        Game,
        Pause,
        PostGame
    }
}
