using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Mvc.ViewFeatures;
using Microsoft.AspNet.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoMVCRC1.Models;

namespace TodoMVCRC1.TagHelpers
{
    [HtmlTargetElement("todo", Attributes = ForTodoItemAttribute)]
    public class ToDoTagHelper:TagHelper
    {
        private const string ForTodoItemAttribute = "asp-todo";

        protected IHtmlGenerator Generator { get; }

        [HtmlAttributeName(ForTodoItemAttribute)]
        public ToDoItem ToDoItem { get; set; }
        public ToDoTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder controlBuilder = new TagBuilder("li");
            output.TagName = "li";
           
            if(ToDoItem!=null)
            {
                controlBuilder.InnerHtml.Append(ToDoItem.Description);
            }
          output.Content.SetHtmlContent(controlBuilder.ToString());
        }
    }
}
