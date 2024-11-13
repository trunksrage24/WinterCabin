using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Radio : MonoBehaviour
{
    [SerializeField]
    private Button radioButton;

    [SerializeField]
    private List<int> puzzles;
    private int currentPuzzle = 0;

    void Start()
    {
        radioButton.OnCLick += HandleButtonClick;
    }

    private void HandleButtonClick(Button button)
    {
        if(IsPuzzleComplete(currentPuzzle))
            currentPuzzle += 1;
        else
            return;
    }

    private bool IsPuzzleComplete(int puzzle)
    {
        switch(puzzle)
        {
            case 1:
            {
                return true;
            }
            case 2:
            {
                return true;
            }
        }
        return false;
    }

}
