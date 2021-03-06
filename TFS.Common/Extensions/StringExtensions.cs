﻿using System;
using System.Security;
using System.Text.RegularExpressions;
using TFS.Helpers;

namespace TFS.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determines if a string "matches" another string in a case insensitive comparison."
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="compare">The compare string.</param>
        /// <returns></returns>
        public static bool Matches(this string source, string compare)
        {
            return string.Equals(source, compare, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Determines if a trimmed string "matches" another trimmed string in a case insensitive comparison."
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="compare">The compare string.</param>
        /// <returns></returns>
        public static bool MatchesTrimmed(this string source, string compare)
        {
            return string.Equals(source.Trim(), compare.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Determines if the input string matches the input regex pattern.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="matchPattern">The regex match pattern.</param>
        /// <returns></returns>
        public static bool MatchesRegex(this string input, string matchPattern)
        {
            return Regex.IsMatch(input, matchPattern,
                                 RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
        }

        public static bool IsValidEmail(this string input)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(input);
                return addr.Address == input;
            }
            catch
            {
                return false;
            }
        }

        public static string Substitute(this string input, string pattern, string replacement)
        {
            return Regex.Replace(input, pattern, replacement);
        }

        public static string Substitute(this string input, string pattern, string replacement, RegexOptions options)
        {
            return Regex.Replace(input, pattern, replacement, options);
        }

        public static string Substitute(this string input, string pattern, MatchEvaluator evaluator)
        {
            return Regex.Replace(input, pattern, evaluator);
        }

        public static string Substitute(this string input, string pattern, MatchEvaluator evaluator, RegexOptions options)
        {
            return Regex.Replace(input, pattern, evaluator, options);
        }

        /// <summary>
        /// Creates a SecureString object from an input string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns></returns>
        public static SecureString MakeSecure(this string input)
        {
            ContractUtils.Requires(!string.IsNullOrEmpty(input), "input");
            var chars = input.ToCharArray();
            var secure = new SecureString();
            foreach (var c in chars)
                secure.AppendChar(c);
            secure.MakeReadOnly();
            return secure;
        }
    }
}