using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HourTrackerUI.Helper_Functions
{
    public static class UI_Functions
    {
        #region Disable TextBox Selection

        private const string NO_SELECT = "non-selectable";
        
        public static void SetNoSelctionOnTextBoxes(params TextBox[] textBoxes)
        {
            SetTag(NO_SELECT, textBoxes);

            SetNoSelect(textBoxes);
        }

        private static void SetTag(string tag, IEnumerable<Control> controls)
        {
            foreach (Control currControl in controls)
            {
                currControl.Tag = tag;
            }
        }

        private static void SetNoSelect(IEnumerable<Control> controls)
        {
            foreach (Control currControl in controls)
            {
                currControl.KeyUp += DisableKeySelect;
                currControl.MouseUp += DisableMouseSelect;
            }
        }

        private static void DisableMouseSelect(object sender, MouseEventArgs e)
        {
            if ((sender is TextBox) && ((sender as TextBox).Tag.ToString() == NO_SELECT))
            {
                RemoveSelection(sender);
            }
        }

        private static void DisableKeySelect(object sender, KeyEventArgs e)
        {
            if ((sender is TextBox) && ((sender as TextBox).Tag.ToString() == NO_SELECT))
            {
                RemoveSelection(sender);
            }
        }


        private static void RemoveSelection(object sender)
        {
            TextBox textbox = sender as TextBox;
            if (textbox != null)
            {
                textbox.SelectionLength = 0;
            }
        }

        #endregion
    }
}
