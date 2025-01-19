using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Database", menuName = "GD/Data/ChemicalDatabase")]
public class ChemicalDatabase : ScriptableObject
{
    public List<ChemicalData> chemicals;
}
