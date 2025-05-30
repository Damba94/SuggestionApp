using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Frontend.Helpers
{
    public static class UiHelper
    {
        public static void SetButtonVisibility(Button button, string currentRole, params string[] allowedRoles)
        {
            button.Visible = allowedRoles.Contains(currentRole);
        }

        public static void SetControlEnabled(Control control, string currentRole, params string[] allowedRoles)
        {
            control.Enabled = allowedRoles.Contains(currentRole);
        }
    }

}
