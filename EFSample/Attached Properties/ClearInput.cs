using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfCore;

namespace EFSample
{
    public class ClearInput : FrameworkAttachedProperty<ClearInput>
    {
        protected override void DoAction(FrameworkElement element, bool value)
        {
            if (value)
            {
                if(element is Grid grid)
                {
                    foreach (var item in grid.Children)
                    {
                        if (item is TextBox text)
                            text.Text = "";
                    }
                }
            }
        }
    }
}
