namespace SuggestionApp.Frontend.Helpers
{
    public class SuggestionStatusComboBox
    {
        public string Text { get; set; } = null!;
        public object Value { get; set; } = null!;

        public override string ToString() => Text;
    }
}
