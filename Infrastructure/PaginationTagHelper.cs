using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "set-up-correctly")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlInfo;
        public PaginationTagHelper(IUrlHelperFactory helper)
        {
            urlInfo = helper;
        }

        public bool SetUpCorrectly { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder finishedTag = new TagBuilder("div");
            TagBuilder indvTag = new TagBuilder("a");

            indvTag.Attributes["href"] = "/Bowler";
            indvTag.InnerHtml.Append("gucci");

            finishedTag.InnerHtml.AppendHtml(indvTag);

            output.Content.AppendHtml(finishedTag.InnerHtml); 
        }
    }
}
