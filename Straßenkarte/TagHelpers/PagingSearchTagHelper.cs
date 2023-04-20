using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Straßenkarte.TagHelpers
{
    [HtmlTargetElement("blog-list-pager")]
    public class PagingSearchTagHelper :TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }
        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div class='w-100 d-flex justify-content-center'";
            StringBuilder str = new StringBuilder();
            str.Append("<ul class='pagination'>");

            for (int i = 1; i < PageCount; i++)
            {
                str.AppendFormat("<li class='page-item {0}'>", i == CurrentPage ? "active" : "");
                str.AppendFormat("<a class='page-link' href='Home/GetBlog?page={0}'>{1}</a>", i, i);
                str.AppendFormat("</li>");
            }
            output.Content.SetHtmlContent(str.ToString());
            base.Process(context, output);

        }
         




    }
}
