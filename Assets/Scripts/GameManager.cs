using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public KanjiItem heldItem;
    public List<PuzzleObject> puzzles;
    public LevelLoader levelLoader;
    public bool finishLevel;

    private static GameManager _instance;
    public static GameManager Inst { get => _instance; }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            ResetPuzzles();
        }
    }

    public void ResetPuzzles()
    {
        foreach (var puzzle in puzzles)
        {
            puzzle.isSolved = false;
        }
    }

    private void Update()
    {
        CheckIfLevelFinished();
        CloseGame();
        Debug.Log("UPDATE");
    }

    private void CheckIfLevelFinished()
    {
        if (puzzles.TrueForAll(isSolved))
        {
            finishLevel = true;
            levelLoader.gameObject.SetActive(true);
        }
    }

    private bool isSolved(PuzzleObject puzzle)
    {
        return puzzle.isSolved;
    }

    private void CloseGame()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
