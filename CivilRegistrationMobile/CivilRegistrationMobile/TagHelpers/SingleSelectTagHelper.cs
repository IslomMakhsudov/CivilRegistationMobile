using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CivilRegistrationMobile.TagHelpers
{
    [HtmlTargetElement("selectOne", Attributes = "asp-for")]
    public class SingleSelectTagHelper : SelectTagHelper
    {
        public SingleSelectTagHelper(IHtmlGenerator generator)
            : base(generator)
        {

        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.TagName = "select";

            var index = output.Attributes.IndexOfName("multiple");
            output.Attributes.RemoveAt(index);

            output.PreContent.AppendHtml("<option value=\"\">Please select an option</option>");

            output.PostContent.Reinitialize();

            if (Items != null)
            {
                foreach (var item in Items)
                {
                    if (item.Selected)
                    {
                        output.PostContent.AppendHtml($"<option selected='selected' value=" + item.Value + ">" + item.Text + "</option>");
                    }
                    else
                    {
                        output.PostContent.AppendHtml($"<option value=" + item.Value + ">" + item.Text + "</option>");
                    }
                }
            }
        }
    }
}
