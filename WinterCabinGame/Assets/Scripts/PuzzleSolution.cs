using UnityEngine;

[CreateAssetMenu(fileName = "PuzzleSolution", menuName = "Scriptable Objects/PuzzleSolution")]
public class PuzzleSolution : ScriptableObject
{
    [field: SerializeField]
    public int level;

    [field: SerializeField]
    public int section;
}
