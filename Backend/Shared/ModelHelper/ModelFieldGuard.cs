namespace Shared.ModelHelper
{
    public class ModelFieldGuard
    {
        public static string Required(
            string? value,
            int maxLength,
            string parameterName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(
                value,
                parameterName);

            value = value.Trim();

            if (value.Length > maxLength)
            {
                throw new ArgumentOutOfRangeException(
                    parameterName,
                    $"Value cannot exceed {maxLength} characters.");
            }

            return value;
        }
    }
}