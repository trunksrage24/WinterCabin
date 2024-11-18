using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Radio : MonoBehaviour
{
    [SerializeField]
    private Button radioButton;

    [SerializeField]
    private Map map;

    [SerializeField]
    private BookDisplay display;

    [SerializeField]
    private int puzzles;

    [SerializeField]
    private PuzzleSolution solution1;

    [SerializeField]
    private PuzzleSolution solution2;

    private int currentPuzzle = 1;

    void Start()
    {
        radioButton.OnCLick += HandleButtonClick;
    }

    private void HandleButtonClick(Button button)
    {
        if(IsPuzzleComplete(currentPuzzle))
            UpdatePuzzle();
        else
            return;
    }

    private void UpdatePuzzle()
    {
        if(currentPuzzle + 1 < puzzles)
            currentPuzzle += 1;
        else
            return;
    }
    private bool IsPuzzleComplete(int puzzle)
    {
        switch(puzzle)
        {
            case <= 2:
            {
                return Puzzle1_2Verification();
            }
            case 3:
            {
                return false;
            }
        }
        return false;
    }

    private bool Puzzle1_2Verification()
    {
        if(map.currentMapPage == solution1.level && map.highlight.id == solution1.section && currentPuzzle == 0)
            return true;
        else if (map.currentMapPage == solution2.level && map.highlight.id == solution2.section && currentPuzzle == 0)
            return true;
        return false;
    }

}
