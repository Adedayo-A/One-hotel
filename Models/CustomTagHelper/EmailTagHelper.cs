using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HotelPremium.Models.CustomTagHelper
{
    public class EmailTagHelper: TagHelper
    {
        public string InnerMessage { get; set; }
        public string EmailAddress { get; set; }

        //<a href="mailto:abraham@yahoo.com">Mail us <a>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + EmailAddress);
            output.Content.SetContent(InnerMessage);
        }
    }
}
