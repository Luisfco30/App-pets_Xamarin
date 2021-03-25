using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppPets.Triggers
{
    public class AgeTrigger : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            int n;
            bool isNumeric = int.TryParse(sender.Text, out n);
            if (string.IsNullOrWhiteSpace(sender.Text) || !isNumeric)
            { // No es numérico
                sender.Text = "";
            }
            else
            { // Es numérico
                if (n < 0)
                {
                    sender.Text = "0";
                }
                else if(n > 20)
                {
                    sender.Text = "20";
                }
            }
        }
    }
}
