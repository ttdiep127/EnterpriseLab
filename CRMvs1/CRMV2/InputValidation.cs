using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CRMV2
{
    internal class InputValidation
    {
        static UIManager _ui;
        static InputValidation()
        {
            _ui = new UIManager();
        }

        internal static bool ValidateID(string str)
        {
            var id = str.Trim();

            if (string.IsNullOrEmpty(id) || id.Length > 10 || (!id.All(Char.IsDigit)))
            {
                _ui.ShowMessage(Strings.IdIsInvalid);
                return false;
            }

            return id.All(Char.IsDigit);
        }

        internal static bool ValidateName(string str)
        {
            var name = str.Trim();
            ;
            if (string.IsNullOrEmpty(name) || name.Length > 50)
            {
                _ui.ShowMessage(Strings.NameIsInvaild);
                return false;
            }

            return true;
        }

        internal static bool ValidateEmail(string str)
        {
            var email = str.Trim();

            if (Regex.IsMatch(email, @"^.+@.+$"))
            {
                return true;
            }

            _ui.ShowMessage(Strings.EmailIsInvalid);
            return false;
        }

        internal static bool ValidatePhoneNumber(string phoneNumber)
        {
            //Delete blank
            phoneNumber = phoneNumber.Replace(" ", "");

            // Valid Phone Number
            if (Regex.IsMatch(phoneNumber, @"^\+?(\d.*){3,}$"))  
            {
                return true;
            }

            _ui.ShowMessage(Strings.PhoneNumberIsInvalid);

            return false;
        }

        internal static bool ValidatePlace(string place)
        {

            if (string.IsNullOrWhiteSpace(place))
            {
                _ui.ShowMessage(Strings.PlaceIsEmpty);
                return false;
            }

            return true;
        }
    }
}