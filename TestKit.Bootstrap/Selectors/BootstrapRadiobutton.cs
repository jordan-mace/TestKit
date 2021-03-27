namespace TestKit.Bootstrap.Selectors
{
    public class BootstrapRadiobutton : LabelledItem
    {
        public BootstrapRadiobutton(string hint) : base(hint) { }

        public static BootstrapRadiobutton WithHint(string hint)
        {
            return new BootstrapRadiobutton(hint);
        }
    }
}
