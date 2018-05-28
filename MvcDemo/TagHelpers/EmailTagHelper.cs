using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MvcDemo.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        private const string EmailDomain = "ppedv.de";

        public string MailTo { get; set; } = "support";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var address = MailTo + "@" + EmailDomain;

            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + address);
            output.Content.SetContent("Kontaktieren Sie uns!");
        }
    }
}
