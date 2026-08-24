namespace Identity.Models
{
    public sealed class AccountRulesModel
    {
        public int MaxPasswordLength { get; set; }
        public int MinPasswordLength { get; set; }
        public bool RequireUpperCase { get; set; }
        public bool RequireLowerCase { get; set; }
        public bool RequireDigit { get; set; }
        public bool RequiredLetter { get; set; }
        public string RegexForEmail { get; set; } = "";
        public string RegexForPhoneNumber { get; set; } = "";
    }
}