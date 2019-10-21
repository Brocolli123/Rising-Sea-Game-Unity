using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //readable by system
public class SaveData
{
    public static SaveData current;

    public List<string> names;
    public List<int> highScores;
}
