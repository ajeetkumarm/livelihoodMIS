using System;
using System.ComponentModel;
using System.Reflection;

namespace ModelLayer
{
    public static class TypeConversionUtility
    {
        #region Convert object the string with null
        /// <summary>
        /// Convert object the string with null.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="checkDbNull">if set to <c>true</c> [check database null].</param>
        /// <param name="defaultReturnValue">The default return value.</param>
        /// <returns>System.String.</returns>
        public static string ToStringWithNull(object expression, bool checkDbNull = false, string defaultReturnValue = "")
        {
            string result = string.Empty;
            if (checkDbNull)
            {
                return IsDbNull(expression) || expression == null || string.IsNullOrWhiteSpace(expression.ToString()) ? defaultReturnValue : expression.ToString();
            }

            if (expression != null)
            {
                return expression.ToString();
            }
            return result;
        }
        #endregion

        #region Convert object To the integer
        /// <summary>
        /// Convert object To the integer
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="checkDbNull">if set to <c>true</c> [check database null].</param>
        /// <param name="defaultReturnValue">The default return value.</param>
        /// <returns>System.Int32.</returns>
        public static int ToInteger(object expression, bool checkDbNull = false, int defaultReturnValue = 0)
        {
            int result = 0;
            if (checkDbNull)
            {
                if (IsDbNull(expression))
                {
                    return defaultReturnValue;
                }
                if (Int32.TryParse(expression.ToString(), out result))
                {
                    return result;
                }
            }
            if (!IsNull(expression))
            {
                Int32.TryParse(expression.ToString(), out result);
                return result;
            }
            else
            {
                return result;
            }
        }
        #endregion

        #region Convert object To the int64
        /// <summary>
        /// Convert object To the int64
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="checkDbNull">if set to <c>true</c> [check database null].</param>
        /// <param name="defaultReturnValue">The default return value.</param>
        /// <returns>Int64.</returns>
        public static Int16 ToInt16(object expression, bool checkDbNull = false, Int16 defaultReturnValue = 0)
        {
            Int16 result = 0;
            if (checkDbNull)
            {
                if (IsDbNull(expression))
                {
                    return defaultReturnValue;
                }
                if (Int16.TryParse(expression.ToString(), out result))
                {
                    return result;
                }
            }
            if (!IsNull(expression))
            {
                Int16.TryParse(expression.ToString(), out result);
                return result;
            }
            else
            {
                return result;
            }
        }
        #endregion

        #region Convert object To the int64
        /// <summary>
        /// Convert object To the int64
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="checkDbNull">if set to <c>true</c> [check database null].</param>
        /// <param name="defaultReturnValue">The default return value.</param>
        /// <returns>Int64.</returns>
        public static Int64 ToInt64(object expression, bool checkDbNull = false, Int64 defaultReturnValue = 0)
        {
            Int64 result = 0;
            if (checkDbNull)
            {
                if (IsDbNull(expression))
                {
                    return defaultReturnValue;
                }
                if (Int64.TryParse(expression.ToString(), out result))
                {
                    return result;
                }
            }
            if (!IsNull(expression))
            {
                Int64.TryParse(expression.ToString(), out result);
                return result;
            }
            else
            {
                return result;
            }
        }
        #endregion

        #region Convert object To the long
        /// <summary>
        /// Convert object To the long
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="checkDbNull">if set to <c>true</c> [check database null].</param>
        /// <param name="defaultReturnValue">The default return value.</param>
        /// <returns>System.Int64.</returns>
        public static long ToLong(object expression, bool checkDbNull = false, long defaultReturnValue = 0)
        {
            long result = 0;
            if (checkDbNull)
            {
                if (IsDbNull(expression))
                {
                    return defaultReturnValue;
                }
                if (long.TryParse(expression.ToString(), out result))
                {
                    return result;
                }
            }
            if (!IsNull(expression))
            {
                long.TryParse(expression.ToString(), out result);
                return result;
            }
            else
            {
                return result;
            }
        }
        #endregion

        #region Convert object To the byte
        /// <summary>
        /// Convert object To the byte.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="checkDbNull">if set to <c>true</c> [check database null].</param>
        /// <param name="defaultReturnValue">The default return value.</param>
        /// <returns>System.Byte.</returns>
        public static byte ToByte(object expression, bool checkDbNull = false, byte defaultReturnValue = 0)
        {
            byte result = 0;
            if (checkDbNull)
            {
                if (IsDbNull(expression))
                {
                    return defaultReturnValue;
                }
                if (byte.TryParse(expression.ToString(), out result))
                {
                    return result;
                }
            }
            if (!IsNull(expression))
            {
                byte.TryParse(expression.ToString(), out result);
                return result;
            }
            else
            {
                return result;
            }

        }
        #endregion

        #region Convert object To the null integer
        /// <summary>
        /// Convert object To the null integer.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="checkDbNull">if set to <c>true</c> [check database null].</param>
        /// <returns>System.Nullable{System.Int32}.</returns>
        public static int? ToNullInteger(object expression, bool checkDbNull = true)
        {
            int result;
            if (checkDbNull)
            {
                if (IsDbNull(expression))
                {
                    return null;
                }
            }
            if (!IsNull(expression))
            {
                Int32.TryParse(expression.ToString(), out result);
                if (result > 0)
                {
                    return result;
                }
                return null;
            }
            else
            {
                return null;
            }

        }
        #endregion

        #region Convert object To the double
        /// <summary>
        /// Convert object To the double.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>System.Double.</returns>
        public static double ToDouble(object expression)
        {
            double result = 0;
            if (expression == null || IsDbNull(expression))
                return result;
            double.TryParse(expression.ToString(), out result);
            return result;
        }
        #endregion

        #region Convert object To the decimal
        /// <summary>
        /// Convert object To the decimal.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>System.Decimal.</returns>
        public static decimal ToDecimal(object expression)
        {
            decimal result = 0;
            if (expression == null || IsDbNull(expression))
                return result;
            decimal.TryParse(expression.ToString(), out result); return result;

        }
        #endregion

        #region Convert object To the boolean
        /// <summary>
        /// Convert object To the boolean.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ToBoolean(object expression)
        {
            bool result = false;
            if (expression == null || IsDbNull(expression))
                return false;

            if (expression.ToString() == "1" || expression.ToString().ToLower() == "true")
            {
                result = true;
            }
            else if (expression.ToString() == "0" || expression.ToString().ToLower() == "false")
            {
                result = false;
            }
            return result;
        }
        #endregion

        #region Convert object To the date time
        /// <summary>
        /// Convert object To the date time.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>DateTime.</returns>
        public static DateTime ToDateTime(Object expression)
        {
            DateTime result = new DateTime();
            if (expression == null || IsDbNull(expression))
                return result;
            if (DateTime.TryParse(expression.ToString(), out result))
            {
                return result;
            }
            return DateTime.MinValue;
        }
        #endregion

        #region Convert object To the time
        /// <summary>
        /// Convert object To the time.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>DateTime.</returns>
        public static TimeSpan ToTime(Object expression)
        {
            TimeSpan result = new TimeSpan();
            if (expression == null || IsDbNull(expression))
                return result;
            if (TimeSpan.TryParse(expression.ToString(), out result))
            {
                return result;
            }
            return TimeSpan.MinValue;
        }
        #endregion

        #region Convert object To the null date time
        /// <summary>
        /// Convert object To the null date time
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>System.Nullable{DateTime}.</returns>
        public static DateTime? ToNullDateTime(Object expression)
        {
            DateTime result;
            if (expression == null || IsDbNull(expression))
                return null;
            if (DateTime.TryParse(expression.ToString(), out result))
            {
                return result;
            }
            return null;
        }
        #endregion

        #region Determines whether the specified expression is numeric
        /// <summary>
        /// Determines whether the specified expression is numeric.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns><c>true</c> if the specified expression is numeric; otherwise, <c>false</c>.</returns>
        public static bool IsNumeric(Object expression)
        {
            if (IsNull(expression))
                return false;
            if (expression == null || expression is DateTime)
                return false;

            if (expression is Int16 || expression is Int32 || expression is Int64 || expression is Decimal || expression is Single || expression is Double || expression is Boolean)
                return true;
            Double result;
            return Double.TryParse(expression.ToString(), out result);
        }
        #endregion

        #region Determines whether [is database null] [the specified value]
        /// <summary>
        /// Determines whether [is database null] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if [is database null] [the specified value]; otherwise, <c>false</c>.</returns>
        public static bool IsDbNull(object value)
        {
            return DBNull.Value.Equals(value);
        }
        #endregion

        #region Determines whether the specified value is null
        /// <summary>
        /// Determines whether the specified value is null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the specified value is null; otherwise, <c>false</c>.</returns>
        public static bool IsNull(object value)
        {
            return value == null;
        }
        #endregion

        #region Convert object To the unique identifier
        /// <summary>
        /// Convert object To the unique identifier
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="checkDbNull">if set to <c>true</c> [check database null].</param>
        /// <returns>Guid.</returns>
        public static Guid ToGuid(object expression, bool checkDbNull = false)
        {
            Guid result;
            if (checkDbNull)
            {
                if (Guid.TryParse(expression.ToString(), out result))
                {
                    return result;
                }
            }
            Guid.TryParse(expression.ToString(), out result);
            return result;
        }
        #endregion


        public static T FromString<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
        public static TimeSpan GetTimeSpanFormString(string timeString)
        {
            DateTime dateWithTime;
            DateTime.TryParse(timeString, out dateWithTime);
            return dateWithTime.TimeOfDay;

        }
        public static string DescriptionAttr<T>(T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else return source.ToString();
        }
    }
}