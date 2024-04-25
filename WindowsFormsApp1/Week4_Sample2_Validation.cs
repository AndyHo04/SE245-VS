using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsBook
{
    class ValidationLibrary {
        public static bool GotPoop (string temp) {
            bool result = false;
            if (temp.Contains ("Poop")) {
                result = true;
            }
            return result;
        }

        // Library of validation functions we can use in future projects

        public static bool IsItFilledIn (string temp) {
            bool result = false;
            if (temp.Length > 0) {
                result = true;
            }
            return result;
        }
        public static bool IsItFilledIn (string temp, int minlen) {
            bool result = false;
            if (temp.Length >= minlen) {
                result = true;
            }
            return result;


        }

        public static bool IsAFutureDate (DateTime temp) {
            bool bInResult;
            if (temp <= DateTime.Now) {
                bInResult = false;
            } else {
                bInResult = true;
            }
            return bInResult;

            //Convert above into Isac's way.
        }

        // Receives a string and we can let user know if it has a semi-valid email format
        public static bool IsValidEmail (string temp) {
            // assume true, but look for bad stuff to make it false
            bool bInResult = true;
            // Look for position of "@"
            int atLocation = temp.IndexOf ("@");
            // Look for position of last period "."
            int periodLocation = temp.LastIndexOf (".");
            // check for minimum length
            if (temp.Length < 8) // if it is less than 8, not valid... Isaac doesn't like Magic Numbers
                bInResult = false;
            else if (atLocation < 2) // if it is -1, not found and needs at least 2 chars in front
                bInResult = false;
            else if (periodLocation + 2 > (temp.Length))
                bInResult = false;
            return bInResult;
        }

        public static bool IsMinimumAmount (int temp, int min) {
            bool blnResult;
            if (temp >= min)
                blnResult = true;
            else
                blnResult = false;
            return blnResult;
        }

        public static bool IsMinimumAmount (double temp, double min) {
            bool blnResult;
            if (temp >= min)
                blnResult = true;
            else
                blnResult = false;
            return blnResult;
        }

    }
}