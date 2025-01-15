using GD.Items;
using GD.Types;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "GD/Data/Chemical")]
public class ChemicalData : ItemData
{
    #region Fields

    [FoldoutGroup("Electrolysis", expanded: true)]
    [SerializeField]
    [Tooltip("Can be used in Electrolysis reactions")]
    private bool enableElectrolysis = false;

    [FoldoutGroup("Electrolysis")]
    [SerializeField, EnableIf("enableElectrolysis")]
    [Tooltip("The 1st product from the reaction")]
    private ChemicalData firstProduct;

    [FoldoutGroup("Electrolysis")]
    [SerializeField, EnableIf("enableElectrolysis")]
    [Tooltip("The 2nd product from the reaction")]
    private ChemicalData secondProduct;

    #endregion Fields

    #region Properties
    public ChemicalData FirstProduct { get => firstProduct; set => firstProduct = value; }
    public ChemicalData SecondProduct { get => secondProduct; set => secondProduct = value; }

    #endregion Properties
}
