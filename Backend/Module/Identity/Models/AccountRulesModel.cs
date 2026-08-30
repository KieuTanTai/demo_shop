namespace Identity.Models
{
    public sealed class AccountRulesModel
    {
        public int MaxPasswordLength { get; set; }
        public int MinPasswordLength { get; set; }
        public bool RequireUppercase { get; set; }
        public bool RequireLowercase { get; set; }
        public bool RequireDigit { get; set; }
        public bool RequiredSpecialCharacter { get; set; }
        public string RegexForEmail { get; set; } = "";
        public string RegexForPhoneNumber { get; set; } = "";
    }
}