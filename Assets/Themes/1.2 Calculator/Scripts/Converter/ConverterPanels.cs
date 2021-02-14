using UnityEngine;
using TMPro;

namespace UnityBase.Calculator
{
    public class ConverterPanels : MonoBehaviour
    {
        [SerializeField] private Calculator calculator;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private TMP_Text resultField;

        [SerializeField] private TMP_Dropdown topDropdownLenght;
        [SerializeField] private TMP_Dropdown bottomDropdownLenght;
        [SerializeField] private TMP_Dropdown topDropdownVolume;
        [SerializeField] private TMP_Dropdown bottomDropdownVolume;

        protected double convertResult = 0.0f;
        public double InputResult { get; private set; }
        public bool UsedLenghtConverter { get; private set; }
        public bool UsedVolumeConverter { get; private set; }

        private void Update()
        {
            InputResult = calculator.Result;
            inputField.text = InputResult.ToString();
        }

        public void ResetAll()
        {
            calculator.ResetInputField();
        }

        public void UseLenghtConverter(bool empty)
        {
            UsedLenghtConverter = true;
            UsedVolumeConverter = false;

            topDropdownLenght.gameObject.SetActive(true);
            bottomDropdownLenght.gameObject.SetActive(true);
            topDropdownVolume.gameObject.SetActive(false);
            bottomDropdownVolume.gameObject.SetActive(false);
        }

        public void UseVolumeConverter(bool empty)
        {
            UsedVolumeConverter = true;
            UsedLenghtConverter = false;

            topDropdownLenght.gameObject.SetActive(false);
            bottomDropdownLenght.gameObject.SetActive(false);
            topDropdownVolume.gameObject.SetActive(true);
            bottomDropdownVolume.gameObject.SetActive(true);
        }
    }
}
