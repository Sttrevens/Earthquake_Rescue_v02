using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SpawnType")]
public class SpawnTypeSO : ScriptableObject
{
    public string nameString;
    public Transform prefab;
    public Sprite sprite;
}
