﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TodoMVCRC1.Resources
{
    using System;
    using System.Reflection;


    /// <summary>
    ///    A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class TodoMVCRC1_Resources_todo
    {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        internal TodoMVCRC1_Resources_todo()
        {
        }

        /// <summary>
        ///    Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TodoMVCRC1.Resources.TodoMVCRC1.Resources.todo", typeof(TodoMVCRC1_Resources_todo).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        ///    Overrides the current thread's CurrentUICulture property for all
        ///    resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        /// <summary>
        ///    Looks up a localized string similar to Sample TODO application(MVC6).
        /// </summary>
        internal static string Heading
        {
            get
            {
                return ResourceManager.GetString("Heading", resourceCulture);
            }
        }

        /// <summary>
        ///    Looks up a localized string similar to Description is required from TODO.
        /// </summary>
        internal static string Msg_Desc_Req
        {
            get
            {
                return ResourceManager.GetString("Msg_Desc_Req", resourceCulture);
            }
        }

        /// <summary>
        ///    Looks up a localized string similar to Title cannot be more than 25 characters long from TODO.
        /// </summary>
        internal static string Msg_Title_Len
        {
            get
            {
                return ResourceManager.GetString("Msg_Title_Len", resourceCulture);
            }
        }

        /// <summary>
        ///    Looks up a localized string similar to Description.
        /// </summary>
        internal static string Plh_Desc
        {
            get
            {
                return ResourceManager.GetString("Plh_Desc", resourceCulture);
            }
        }

        /// <summary>
        ///    Looks up a localized string similar to Title.
        /// </summary>
        internal static string Plh_Title
        {
            get
            {
                return ResourceManager.GetString("Plh_Title", resourceCulture);
            }
        }
    }
}
