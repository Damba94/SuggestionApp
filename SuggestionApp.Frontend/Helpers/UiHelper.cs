namespace SuggestionApp.Frontend.Helpers
{
    public static class UiHelper
    {
        public static void SetButtonVisibility(Button button, string currentRole, params string[] allowedRoles)
        {
            button.Visible = allowedRoles.Contains(currentRole);
        }

        public static void SetComboBoxVisibility(ComboBox comboBox, string currentRole, params string[] allowedRoles)
        {
            comboBox.Visible = allowedRoles.Contains(currentRole);
        }

        public static void SetCheckBoxVisibility(CheckBox checkBox, string currentRole, params string[] allowedRoles)
        {
            checkBox.Visible = allowedRoles.Contains(currentRole);
        }

        public static void SetDatePickerVisibility(DateTimePicker datePicker, string currentRole, params string[] allowedRoles)
        {
            datePicker.Visible = allowedRoles.Contains(currentRole);
        }
    }



}
