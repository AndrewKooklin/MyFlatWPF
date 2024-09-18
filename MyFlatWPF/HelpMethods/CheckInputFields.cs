using MyFlatWPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyFlatWPF.HelpMethods
{
    public class CheckInputFields
    {
        public bool CheckOrderFormFields(HomeView homeView, object fields)
        {
            var fieldElements = (object[])fields;
            string name = fieldElements[0].ToString();
            string email = fieldElements[1].ToString();
            string mobile = fieldElements[2].ToString();
            ComboBoxItem cbItem = (ComboBoxItem)fieldElements[3];
            string serviceName = cbItem.Content.ToString();
            string message = fieldElements[4].ToString();

            if (String.IsNullOrEmpty(name))
            {
                homeView.tbNameError.Text = "Fill field \"Your Name\"";
                return false;
            }
            if (String.IsNullOrEmpty(email))
            {
                homeView.tbEmailError.Text = "Fill field \"Your Email\"";
                return false;
            }

            if (!CheckEmail(email))
            {
                homeView.tbEmailError.Text = "Email field format name@site.com";
                return false;
            }

            return true;
        }

        private bool CheckEmail(string email)
        {
            MailAddress mail = new MailAddress(email);
            bool result = mail.Address == email;
            if (result)
            {
                return true;
            }
            else return false;
        }
    }
}
