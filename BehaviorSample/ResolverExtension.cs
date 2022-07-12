using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace BehaviorSample
{
    /// <summary>
    /// https://stackoverflow.com/questions/33097460/clean-way-to-injecting-dependency-to-wpf-behavior
    /// </summary>
    public sealed class ResolverExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var provideValueTarget = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));

            // Find the type of the property we are resolving
            var targetProperty = provideValueTarget.TargetProperty as PropertyInfo;
            if (targetProperty == null)
            {
                throw new InvalidProgramException();
            }
            //Setter의 Value에 바인딩되어있는 경우
            if (targetProperty.PropertyType == typeof(object) && targetProperty.Name == "Value")
            {
                var type = ((Setter)provideValueTarget.TargetObject).Property.PropertyType;
                var returnInstance = App.Current.Services.GetService(type);
                return returnInstance;
            }
            else
            {
                // Find the implementation of the type in the container
                var returnInstance = App.Current.Services.GetService(targetProperty.PropertyType);
                return returnInstance;
            }
        }
    }
}
