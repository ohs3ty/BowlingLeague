using BowlingLeague.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-info")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlInfo;
        public PaginationTagHelper(IUrlHelperFactory helper)
        {
            urlInfo = helper;
        }

        public bool SetUpCorrectly { get; set; }
        public PageNumberingInfo PageInfo { get; set; }

        //Dictionary with key value pairs
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }


        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelp = urlInfo.GetUrlHelper(ViewContext); 
            TagBuilder finishedTag = new TagBuilder("div");

            for (int i = 1; i <= PageInfo.NumPages; i++)
            { 
                TagBuilder indvTag = new TagBuilder("a");

                KeyValuePairs["pageNum"] = i;
                indvTag.Attributes["href"] = urlHelp.Action("Index", KeyValuePairs);

                //add css
                if (PageClassesEnabled)
                {
                    indvTag.AddCssClass(PageClass);
                    indvTag.AddCssClass(i == PageInfo.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                indvTag.InnerHtml.Append(i.ToString());

                finishedTag.InnerHtml.AppendHtml(indvTag);
            }

            output.Content.AppendHtml(finishedTag.InnerHtml); 
        }
    }
}
