namespace Marketoo.Common.Validations
{
    public class TelemetryValidation
    {
        public static bool IsLocationValid(double location)
        {
            bool isValid = true;

            if (location <= 0)
                isValid = false;
            else if (location > 100)
                isValid = false;

            return isValid;
        }
    }
}
