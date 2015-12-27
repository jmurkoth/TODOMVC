using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Mvc.ViewFeatures;
using Microsoft.AspNet.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoMVCRC1.Models;

namespace TodoMVCRC1.TagHelpers
{
    [HtmlTargetElement("todo", Attributes = ForTodoItemAttribute)]
    public class ToDoTagHelper:TagHelper
    {
        private const string ForTodoItemAttribute = "asp-todo";
        private const string TypeAttribute = "asp-type";

        protected IHtmlGenerator Generator { get; }

        [HtmlAttributeName(TypeAttribute)]
        public string   Type { get; set; }


        [HtmlAttributeName(ForTodoItemAttribute)]
        public ToDoItem ToDoItem { get; set; }
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public ToDoTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }
        //public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        //{
        //    return base.ProcessAsync(context, output);
        //}
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            
            if(ToDoItem!=null)
            {
                output.TagName = "li";
                output.Attributes["class"] = ToDoItem.IsComplete ? "complete" : string.Empty;
                TagBuilder article = new TagBuilder("article");
                article.TagRenderMode = TagRenderMode.Normal;
                // The delete button and form
                TagBuilder frmDelete = Generator.GenerateForm(ViewContext, "Delete", "Home",new { id = ToDoItem.ID,type=Type }, "POST", new { @class = "form-inline" });
                frmDelete.TagRenderMode = TagRenderMode.Normal;
                TagBuilder deleteButton = new TagBuilder("button");
                deleteButton.Attributes["type"] = "submit";
                TagBuilder btnIcon = new TagBuilder("i");
                btnIcon.AddCssClass("glyphicon glyphicon-trash");
                deleteButton.InnerHtml.Append(btnIcon);
                frmDelete.InnerHtml.Append(deleteButton);
                article.InnerHtml.Append(frmDelete);
                // The update form and button
              
                TagBuilder frmUpdate = Generator.GenerateForm(ViewContext, "Update", "Home", new { id = ToDoItem.ID , type = Type }, "POST", new { @class = "form-inline" });
                frmUpdate.TagRenderMode = TagRenderMode.Normal;
             
                TagBuilder hdnInput = new TagBuilder("input");
                hdnInput.Attributes["type"] = "hidden";
                hdnInput.Attributes["name"] = "iscomplete";
                hdnInput.Attributes["value"] = ToDoItem.IsComplete.ToString();
                frmUpdate.InnerHtml.Append(hdnInput);

                TagBuilder updateButton = new TagBuilder("button");
                updateButton.Attributes["type"] = "submit";
                TagBuilder btnIconUpd = new TagBuilder("i");
                btnIconUpd.AddCssClass(ToDoItem.IsComplete? "glyphicon glyphicon-star" : "glyphicon glyphicon-star-empty");
                updateButton.InnerHtml.Append(btnIconUpd);
                frmUpdate.InnerHtml.Append(updateButton);
                article.InnerHtml.Append(frmUpdate);

                TagBuilder frmSimple = new TagBuilder("form");
                frmSimple.AddCssClass("form-inline");
                TagBuilder updLink = Generator.GenerateActionLink(string.Empty, "edit", "home", string.Empty, string.Empty, string.Empty, new { id = ToDoItem.ID }, null);
                TagBuilder anchIcon = new TagBuilder("i");
                anchIcon.AddCssClass("glyphicon glyphicon-edit");
                updLink.InnerHtml.Append(anchIcon);
                frmSimple.InnerHtml.Append(updLink);
                article.InnerHtml.Append(frmSimple);

                TagBuilder titleTagH = new TagBuilder("h2");
                titleTagH.InnerHtml.AppendHtml(ToDoItem.Title);
                article.InnerHtml.Append(titleTagH);

                TagBuilder descriptionTagP = new TagBuilder("p");
                descriptionTagP.AddCssClass(ToDoItem.IsComplete ? "complete" : string.Empty);
                descriptionTagP.InnerHtml.AppendHtml(ToDoItem.Description);
                article.InnerHtml.Append(descriptionTagP);

                TagBuilder timeTagP = new TagBuilder("p");
                timeTagP.AddCssClass("time");
                timeTagP.InnerHtml.AppendHtml(ToDoItem.CreatedDate.ToString("MMM dd yyyy hh:mm tt"));
                article.InnerHtml.Append(timeTagP);
                output.Content.Append(article);
                output.TagMode = TagMode.StartTagAndEndTag;
                base.Process(context, output);
            }
        }
    }
}
