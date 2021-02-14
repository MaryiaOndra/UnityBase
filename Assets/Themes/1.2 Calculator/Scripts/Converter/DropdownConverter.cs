using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UnityBase.Calculator
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public class DropdownConverter<T> : MonoBehaviour
    {
        private TMP_Dropdown dropdown;
        private List<string> optionsNames;

        private void Awake()
        {
            dropdown = GetComponent<TMP_Dropdown>();
            CreateOptionsFromEnum();
            AddNewOptionsToList();
        }

        private void AddNewOptionsToList()
        {
            dropdown.ClearOptions();
            dropdown.AddOptions(optionsNames);
        }

        private void CreateOptionsFromEnum()
        {
            string[] names = Enum.GetNames(typeof(T));
            optionsNames = new List<string>(names);
        }
    }
}
