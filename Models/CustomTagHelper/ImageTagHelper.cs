using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HotelPremium.Models.CustomTagHelper
{
    public class ImageTagHelper : TagHelper
    {
        public string ImageSource { get; set; }
        public string InnerMessage { get; set; }

        //<img src="" alt="" />
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //output.TagName
            //output.Attributes.SetAttribute
        }
    }
}
