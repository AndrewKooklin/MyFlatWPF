using MyFlatWPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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
            if (name.Length < 3)
            {
                homeView.tbNameError.Text = "Length of at least 3 characters.";
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

            if (String.IsNullOrEmpty(mobile))
            {
                homeView.tbMobileError.Text = "Fill field \"Your Mobile\"";
                return false;
            }
            if (!CheckPhone(email))
            {
                homeView.tbMobileError.Text = "Field must contain 11 digits";
                return false;
            }

            if (String.IsNullOrEmpty(serviceName))
            {
                homeView.tbServiceError.Text = "Choose service";
                return false;
            }

            if (String.IsNullOrEmpty(message))
            {
                homeView.tbMessageError.Text = "Fill field \"Your Message\"";
                return false;
            }
            if(message.Length < 5)
            {
                homeView.tbMessageError.Text = "Length of at least 5 characters.";
                return false;
            }
            else
            {
                homeView.tbNameError.Text = "";
                homeView.tbEmailError.Text = "";
                homeView.tbMobileError.Text = "";
                homeView.tbServiceError.Text = "";
                homeView.tbMessageError.Text = "";
                return true;
            }

            
        }

        private bool CheckEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                bool result = mail.Address == email;
                if (result)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        private bool CheckPhone(string phoneNumber)
        {
            string expr = @"^d{11}$";
            if (Regex.IsMatch(phoneNumber, expr))
            {
                return true;
            }
            else return false;
        }
    }
}
