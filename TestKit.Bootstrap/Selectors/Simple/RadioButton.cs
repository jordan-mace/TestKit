namespace TestKit.Bootstrap.Selectors
{
    /// <summary>
    /// Used to identify a Bootstrap radio button on a webpage.
    /// </summary>
    public class RadioButton : LabelledItem
    {
        public RadioButton(string hint) : base(hint) { }

        public static RadioButton WithHint(string hint)
        {
            return new RadioButton(hint);
        }
    }
}
