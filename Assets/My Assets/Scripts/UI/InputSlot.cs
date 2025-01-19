using GD.Items;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum CraftStations { Electrolysis, Example}

public class InputSlot : MonoBehaviour
{
    [SerializeField]
    [Tooltip("")]
    private TMP_Dropdown dropdown;

    [SerializeField]
    [Tooltip("")]
    private Inventory playerInventory;

    [SerializeField]
    [Tooltip("")]
    private ChemicalDatabase database;

    [SerializeField]
    [Tooltip("The station this input represents")]
    private CraftStations station;

    [SerializeField]
    [Tooltip("The item selected in the dropdown")]
    private ChemicalData currentItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        switch (station)
        {
            case CraftStations.Electrolysis:
                {
                    foreach (var chemical in database.chemicals)
                    {
                        if (chemical.ElectrolysisEnabled)
                        {
                            if (playerInventory.Contains(chemical))
                            {
                                TMP_Dropdown.OptionData optionData = new();
                                optionData.text = chemical.Name;
                                dropdown.options.Add(optionData);
                            }
                        }
                    }
                }
                break;
            default:
                {

                }
                break;
        }
    }

    public void SelectItem(int index)
    {
        if (dropdown.options[index].text == "None")
        {
            currentItem = null;
        }

        foreach (var chem in database.chemicals)
        {
            if (chem.Name == dropdown.options[index].text)
            {
                currentItem = chem;
            }
        }
    }
}
