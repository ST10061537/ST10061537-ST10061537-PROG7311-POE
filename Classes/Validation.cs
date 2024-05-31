using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AgriEnergy.Classes
{
    //----------------------------//
    // START OF CLASS
    //----------------------------//
    public class Validation
    {
        //---------------------------------//
        // VARIABLE FOR ERROR MESSAGES
        //---------------------------------//
        public string ErrorMessage { get; private set; }
        //---------------------------------//
        // METHOD TO VALIDATE FULL NAME
        //---------------------------------//
        public bool ValidateFullName(string fullName)
        {
            // Check if the full name is not empty
            if (string.IsNullOrEmpty(fullName))
            {
                ErrorMessage = "Full name is required.";
                return false;
            }
            return true;
        }
        //---------------------------------//
        // METHOD TO VALIDATE MOBILE NUMMBER
        //---------------------------------//
        public bool ValidateMobileNumber(string mobileNumber)
        {
            // Check if the mobile number is not empty
            if (string.IsNullOrEmpty(mobileNumber))
            {
                ErrorMessage = "Mobile number is required.";
                return false;
            }

            // Check if the mobile number contains only digits
            if (!int.TryParse(mobileNumber, out _))
            {
                ErrorMessage = "Invalid mobile number.";
                return false;
            }
            return true;
        }
        //---------------------------------//
        // METHOD TO VALIDATE EMAIL
        //---------------------------------//
        public bool ValidateEmail(string email)
        {
            // Check if the email is not empty
            if (string.IsNullOrEmpty(email))
            {
                ErrorMessage = "Email is required.";
                return false;
            }

            // Using a regular expression to validate the email format
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            bool isEmailValid = Regex.IsMatch(email, emailPattern);

            if (!isEmailValid)
            {
                ErrorMessage = "Invalid email format.";
            }
            return isEmailValid;
        }
        //---------------------------------//
        // METHOD TO VALIDATE USERNAME
        //---------------------------------//
        public bool ValidateUsername(string username)
        {
            // Check if the username is not empty
            if (string.IsNullOrEmpty(username))
            {
                ErrorMessage = "Username is required.";
                return false;
            }

            // Check if the username contains an underscore
            if (!username.Contains("_"))
            {
                ErrorMessage = "Username must contain an underscore.";
                return false;
            }

            // Check if the username is no more than 5 characters in length
            if (username.Length > 5)
            {
                ErrorMessage = "Username must be no more than 5 characters in length.";
                return false;
            }
            return true;
        }
        //---------------------------------//
        // METHOD TO VALIDATE PASSWORD
        //---------------------------------//
        public bool ValidatePassword(string password)
        {
            // Check if the password is not empty
            if (string.IsNullOrEmpty(password))
            {
                ErrorMessage = "Password is required.";
                return false;
            }

            // Check if the password is at least 8 characters long
            if (password.Length < 8)
            {
                ErrorMessage = "Password must be at least 8 characters long.";
                return false;
            }

            // Check if the password contains at least one capital letter
            if (!password.Any(char.IsUpper))
            {
                ErrorMessage = "Password must contain at least one capital letter.";
                return false;
            }

            // Check if the password contains at least one number
            if (!password.Any(char.IsDigit))
            {
                ErrorMessage = "Password must contain at least one number.";
                return false;
            }

            // Check if the password contains at least one special character
            if (!password.Any(c => !char.IsLetterOrDigit(c)))
            {
                ErrorMessage = "Password must contain at least one special character.";
                return false;
            }
            return true;
        }
        //---------------------------------//
        // METHOD TO VALIDATE PASSWORD
        //---------------------------------//
        public bool ValidateConfirmPassword(string password, string confirmPassword)
        {
            // Check if the password and confirm password match
            if (password != confirmPassword)
            {
                ErrorMessage = "Passwords do not match.";
                return false;
            }

            return true;
        }
        //---------------------------------//
        // METHOD TO VALIDATE ALL
        // REGISTRATION INPUT
        //---------------------------------//
        public bool ValidateRegistrationInput(string fullName, string mobileNumber, string email, string username, string password, string confirmPassword)
        {
            // Validate each input field individually
            bool isFullNameValid = ValidateFullName(fullName);
            bool isMobileNumberValid = ValidateMobileNumber(mobileNumber);
            bool isEmailValid = ValidateEmail(email);
            bool isUsernameValid = ValidateUsername(username);
            bool isPasswordValid = ValidatePassword(password);
            bool isConfirmPasswordValid = ValidateConfirmPassword(password, confirmPassword);

            // Return true if all input fields are valid, otherwise return false
            return isFullNameValid && isMobileNumberValid && isEmailValid && isUsernameValid && isPasswordValid && isConfirmPasswordValid;
        }
        //---------------------------------//
        // METHOD TO VALIDATE ALL
        // FARMER INPUT
        //---------------------------------//
        public bool ValidateRegistrationInput2(string firstName, string lastName, string mobileNumber, string email, string username, string password, string confirmPassword, string location)
        {
            // Check if any of the fields are empty
            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(mobileNumber) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(location))
            {
                ErrorMessage = "Please fill in all the required fields.";
                return false;
            }

            // Check if the first name or last name contain any numeric characters
            if (firstName.Any(char.IsDigit) || lastName.Any(char.IsDigit))
            {
                ErrorMessage = "First name, last name or location cannot contain numbers.";
                return false;
            }

            // Check if the mobile number only contains numbers
            if (!mobileNumber.All(char.IsDigit))
            {
                ErrorMessage = "Mobile number can only contain numbers.";
                return false;
            }

            // Check if the email is in a valid format
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                ErrorMessage = "Email is not in a valid format.";
                return false;
            }

            // Check if the username contains an underscore and is no more than 5 characters in length
            if (!username.Contains("_") || username.Length > 5)
            {
                ErrorMessage = "Username must contain an underscore and be no more than 5 characters in length.";
                return false;
            }

            // Check if the password is no more than 8 characters in length, contains a capital letter, a number, and a special character
            if (password.Length > 8 || !password.Any(char.IsUpper) || !password.Any(char.IsDigit) || !password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                ErrorMessage = "Password must be no more than 8 characters in length, contain a capital letter, a number, and a special character.";
                return false;
            }

            // Check if the password and confirm password fields match
            if (password != confirmPassword)
            {
                ErrorMessage = "Password and confirm password fields do not match.";
                return false;
            }

            // All fields are filled and valid, return true
            return true;
        }
        //---------------------------------//
        // METHOD TO VALIDATE ALL
        // PRODUCT INPUT
        //---------------------------------//
        public bool ValidateProductInput(string name, string category, string productionDate, string description)
        {
            // Check if any of the fields are empty
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(category) ||
                string.IsNullOrWhiteSpace(productionDate) ||
                string.IsNullOrWhiteSpace(description))
            {
                ErrorMessage = "Please fill in all the required fields.";
                return false;
            }

            // Check if the name or category contains any numeric characters
            if (name.Any(char.IsDigit) || category.Any(char.IsDigit) || (description.Any(char.IsDigit)))
            {
                ErrorMessage = "Name, category or description cannot contain numbers.";
                return false;
            }

            // All fields are filled and valid, return true
            return true;
        }
    }//--------------------END-OF-CLASS---------------------------//
}//--------------------------ENDOFFILE----------------------------//