using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace C_Final
{
    class ValidationLibrary
    //create validation class for validation
    {
        public static bool IsFilled(string strValue)
        {
            
            bool result = false;

            if (strValue.Length > 0)
            {
                result = true;
            }

            return result;
        }
        public static bool IsPastDate(DateTime dtValue)
        {
            bool blnResult = false;
            if (dtValue > DateTime.MinValue && dtValue <= DateTime.Now)
            {
                blnResult = true;
            }
            else
            {
                blnResult = false;
            }
            return blnResult;
        }

        public static bool IsMinimunInt(int strValue)
        {
            bool blnResult;
            if (strValue > 0)
            {
                blnResult = true;
            }
            else
            {
                blnResult = false;
            }
            return blnResult;
        }

        public static bool IsMinimunDouble(double strValue)
        {
            bool blnResult;
            if (strValue > 0)
            {
                blnResult = true;
            }
            else
            {
                blnResult = false;
            }
            return blnResult;
        }
    }
}
