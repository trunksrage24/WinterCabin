using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BookContent", menuName = "Scriptable Objects/BookContent")]
public class BookContent : ScriptableObject
{
    [field: SerializeField]
    private List<Material> contents;
}
