using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace IisExpressWebServer
{
    static class Argument
    {
        /// <summary>
        /// Checks if a list is empty
        /// </summary>
        public static void CheckIfEmpty<T>(this IEnumerable<T> enumerable, string argumentName)
        {
            if (!enumerable.Any())
            {
                throw new ArgumentNullException(argumentName, " cannot be null.");
            }
        }

        /// <summary>
        /// Check if object is null
        /// </summary>
        public static void CheckIfNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName, " cannot be null.");
            }
        }

        /// <summary>
        /// Check if string is null or empty
        /// </summary>
        public static void CheckIfNullOrEmpty(string argument, string argumentName)
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentNullException(argumentName, " cannot be null.");
            }
        }

        /// <summary>
        /// Check if decimal is null or less than minimum value
        /// </summary>
        public static void CheckDecimalIfNullOrValue(decimal? argument, decimal minValue, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName, " cannot be null.");
            }
            if (argument < minValue)
            {
                throw new ArgumentException(string.Format("{0} is less than minimum required value {1}", argumentName, minValue.ToString(CultureInfo.InvariantCulture)), argumentName);
            }
        }

        /// <summary>
        /// Check if int is null or less than minimum value
        /// </summary>
        public static void CheckIntIfNullOrValue(int? argument, int minValue, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName, " cannot be null.");
            }
            if (argument < minValue)
            {
                throw new ArgumentException(string.Format("{0} is less than minimum required value {1}", argumentName, minValue.ToString(CultureInfo.InvariantCulture)), argumentName);
            }

        }
    }
}
