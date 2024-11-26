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
    private int puzzles;

    [SerializeField]
    private PuzzleSolution solution1;

    [SerializeField]
    private PuzzleSolution solution2;

    [SerializeField]
    private GameObject puzzleUI1;

    [SerializeField]
    private GameObject puzzleUI2;

    private int currentPuzzle = 1;

    void Start()
    {
        radioButton.OnCLick += HandleButtonClick;
        UIUpdate();
    }

    private void HandleButtonClick(Button button)
    {
        Debug.Log($"Am here uwu I was here");

        if(IsPuzzleComplete(currentPuzzle))
        {
            UpdatePuzzle();
            Debug.Log($"{currentPuzzle}");
        }
        else
            return;
    }

    private void UpdatePuzzle()
    {
        if(currentPuzzle + 1 <= puzzles)
        {
            currentPuzzle += 1;
            UIUpdate();
        }
        else
            return;
    }
    private bool IsPuzzleComplete(int puzzle)
    {
        switch(puzzle)
        {
            case <= 2:
            {
                Debug.Log($"All in baby");
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
        if(map.currentMapPage + 1 == solution1.level && map.selectedSection == solution1.section && currentPuzzle == 1)
        {
            Debug.Log($"solved");
            return true;
        }
        else if (map.currentMapPage + 1 == solution2.level && map.selectedSection == solution2.section && currentPuzzle == 2)
        {
            Debug.Log($"solved");
            return true;
        }
        Debug.Log($"{map.currentMapPage + 1} {map.selectedSection}");
        return false;
    }
    private void UIUpdate()
    {
        if (currentPuzzle == 1)
            puzzleUI1.SetActive(true);
        else
        {
            puzzleUI1.SetActive(false);
            puzzleUI2.SetActive(true);
        }
        
    }
}
