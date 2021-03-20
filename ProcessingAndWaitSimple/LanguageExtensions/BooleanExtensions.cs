namespace ProcessingAndWait.LanguageExtensions
{
    public static class BooleanExtensions
    {
        /// <summary>
        /// Convert bool to Yes/No
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToYesNoString(this bool value) => value ? "Yes" : "No";
    }
}