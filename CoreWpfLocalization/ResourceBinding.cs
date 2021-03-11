using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace CoreWpfLocalization
{
    public class ResourceBinding : MarkupExtension
    {
        private readonly dynamic _dr;

        public string Key { get; set; }

        public ResourceBinding()
        {
            _dr = App.Current.Resources["DR"] as DynamicResource;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Key))
            {
                throw new NullReferenceException("Key is a required value. ");
            }
            return _dr[Key];
        }
    }
}
