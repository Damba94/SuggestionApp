using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Frontend.Helpers
{
    public class SuggestionStatusComboBox
    {
        public string Text { get; set; } = null!;
        public object Value { get; set; }=null!;

        public override string ToString() => Text;
    }
}
