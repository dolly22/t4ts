﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace T4TS.Build.Builder.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("T4TS.Build.Builder.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;#@ template language=&quot;C#&quot; debug=&quot;true&quot; hostspecific=&quot;true&quot; #&gt;
        ///&lt;#@ output extension=&quot;.d.ts&quot; #&gt;
        ///&lt;#@ assembly name=&quot;System.Core&quot; #&gt;
        ///&lt;#@ assembly name=&quot;Microsoft.VisualStudio.Shell.Interop.8.0&quot; #&gt;
        ///&lt;#@ assembly name=&quot;EnvDTE&quot; #&gt;
        ///&lt;#@ assembly name=&quot;EnvDTE80&quot; #&gt;
        ///&lt;#@ import namespace=&quot;System.Collections.Generic&quot; #&gt;
        ///&lt;#@ import namespace=&quot;System.Linq&quot; #&gt;
        ///&lt;#@ import namespace=&quot;System.Text&quot; #&gt;
        ///&lt;#@ import namespace=&quot;EnvDTE&quot; #&gt;
        ///&lt;#@ import namespace=&quot;Microsoft.VisualStudio.Shell.Interop&quot; #&gt;
        ///&lt;#@ import namespace [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TemplatePrefix {
            get {
                return ResourceManager.GetString("TemplatePrefix", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;#+
        ////// &lt;summary&gt;
        ////// These settings can be used to customize the output of T4TS.
        ////// The default for all settings are determined by T4TS.tt in ReadSettings().
        ////// &lt;/summary&gt;
        ///readonly Dictionary&lt;string, object&gt; SettingsValues = new Dictionary&lt;string, object&gt;()
        ///{
        ///    // The default module of the generated interface. If a module is 
        ///    // not specified by the TypeScriptInterfaceAttribute, the interface 
        ///    // will belong to this module (may be empty, in which case the 
        ///    // interface will be glo [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TemplateSettings {
            get {
                return ResourceManager.GetString("TemplateSettings", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #&gt;.
        /// </summary>
        internal static string TemplateSuffix {
            get {
                return ResourceManager.GetString("TemplateSuffix", resourceCulture);
            }
        }
    }
}
