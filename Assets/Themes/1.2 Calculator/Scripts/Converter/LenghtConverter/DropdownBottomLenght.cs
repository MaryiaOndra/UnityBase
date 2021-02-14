namespace UnityBase.Calculator
{
    public class DropdownBottomLenght : DropdownConverter<ConverterEnums.LenghtTypes>
    {
        public int BottomIndex { get; private set; }

        public void AddBottomIndex(int index)
        {
            BottomIndex = index;
        }
    }
}
