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
    private GameObject[] puzzleUIs;

    [SerializeField]
    private GameObject[] dialogs;

    private int currentPuzzle = 1;

    private bool dialogPhase = true;

    private int dialogCounter = 0;

    void Start()
    {
        radioButton.OnCLick += HandleButtonClick;
        ShowDialog();
    }

    private void HandleButtonClick(Button button)
    {

        if(!dialogPhase)
        {
            if(IsPuzzleComplete(currentPuzzle))
            {
                UpdatePuzzle();
                Debug.Log($"{currentPuzzle}");
            }
            else
                return;
        }
        else
        {
            ShowDialog();
        }
    }

    private void UpdatePuzzle()
    {
        if(currentPuzzle + 1 <= puzzles)
        {
            currentPuzzle += 1;
            dialogPhase = true;
            ShowDialog();
        }
        else
        {
            ShowDialog();
            return;
        }
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
            puzzleUIs[0].SetActive(true);
        else if (currentPuzzle == 2)
        {
            puzzleUIs[0].SetActive(false);
            puzzleUIs[1].SetActive(true);
        }
        else
        {
            puzzleUIs[1].SetActive(false);
            puzzleUIs[2].SetActive(true);
        }

        dialogs[dialogCounter - 1].SetActive(false);
    }

    private void ShowDialog()
    {
        if (dialogCounter == 0)
        {
            dialogs[dialogCounter].SetActive(true);
            dialogCounter += 1;
        }
        else if (dialogCounter < 6 & currentPuzzle == 1 || dialogCounter < 16 & currentPuzzle == 2)
        {
            dialogs[dialogCounter].SetActive(true);
            dialogs[dialogCounter - 1].SetActive(false);
            dialogCounter += 1;
        }
        else
        {
            dialogPhase = false;
            UIUpdate();
        }

    }
}
