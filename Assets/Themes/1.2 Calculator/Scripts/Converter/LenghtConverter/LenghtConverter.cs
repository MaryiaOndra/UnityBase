using TMPro;
using UnityEngine;

namespace UnityBase.Calculator
{
    public class LenghtConverter : DropdownConverter<ConverterEnums.LenghtTypes>
    {
        [SerializeField] private TMP_Text resultField;
        [SerializeField] private DropdownBottomLenght bottomLenght;

        private double convertedResult;
        private double resultInMeters;
        private double inputResult;

        private int topIndex = 0;
        private int bottomIndex = 0;

        private void Update()
        {
            inputResult = gameObject.GetComponentInParent<ConverterPanels>().InputResult;
            bottomIndex = bottomLenght.BottomIndex;

            ConvertToMeters(topIndex);
            ConvertLenght(bottomIndex);
            resultField.text = convertedResult.ToString();
        }

        public void AddTopIndex(int index)
        {
            topIndex = index;
        }

        private void ConvertToMeters(int index)
        {
            switch (index)
            {
                case (int)ConverterEnums.LenghtTypes.Milimeters:
                    resultInMeters = inputResult / 1000f;
                    break;
                case (int)ConverterEnums.LenghtTypes.Centimeters:
                    resultInMeters = inputResult / 100f;
                    break;
                case (int)ConverterEnums.LenghtTypes.Kilometers:
                    resultInMeters = inputResult * 1000;
                    break;
                case (int)ConverterEnums.LenghtTypes.Foot:
                    resultInMeters = inputResult / 3.281f;
                    break;
                case (int)ConverterEnums.LenghtTypes.Inches:
                    resultInMeters = inputResult / 39.37f;
                    break;
                case (int)ConverterEnums.LenghtTypes.Miles:
                    resultInMeters = inputResult * 1609;
                    break;
                case (int)ConverterEnums.LenghtTypes.Yards:
                    resultInMeters = inputResult / 1.094f;
                    break;
                case (int)ConverterEnums.LenghtTypes.Meters:
                    resultInMeters = inputResult;
                    break;
            }
        }

        private void ConvertLenght(int index)
        {
            switch (index)
            {
                case (int)ConverterEnums.LenghtTypes.Milimeters:
                    Debug.Log("2Milimeters");
                    convertedResult = resultInMeters * 1000;
                    break;
                case (int)ConverterEnums.LenghtTypes.Centimeters:
                    Debug.Log("2Centimeters");
                    convertedResult = resultInMeters * 100;
                    break;
                case (int)ConverterEnums.LenghtTypes.Kilometers:
                    convertedResult = resultInMeters / 1000;
                    break;
                case (int)ConverterEnums.LenghtTypes.Foot:
                    convertedResult = resultInMeters * 3.281;
                    break;
                case (int)ConverterEnums.LenghtTypes.Inches:
                    convertedResult = resultInMeters * 39.37f;
                    break;
                case (int)ConverterEnums.LenghtTypes.Miles:
                    convertedResult = resultInMeters / 1609;
                    break;
                case (int)ConverterEnums.LenghtTypes.Yards:
                    convertedResult = resultInMeters * 1.094f;
                    break;
                case (int)ConverterEnums.LenghtTypes.Meters:
                    convertedResult = resultInMeters;
                    break;
            }
        }
    }
}


