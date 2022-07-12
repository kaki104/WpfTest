using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BehaviorSample
{
    /// <summary>
    /// 스타일에서 Behavior을 추가해서 사용할 수 있도록 지원합니다.
    /// </summary>
    /// <remarks>https://stackoverflow.com/questions/1647815/how-to-add-a-blend-behavior-in-a-style-setter</remarks>
    /// <typeparam name="TComponent"></typeparam>
    /// <typeparam name="TBehavior"></typeparam>
    public class AttachableForStyleBehavior<TComponent, TBehavior> : Behavior<TComponent>
            where TComponent : DependencyObject
            where TBehavior : AttachableForStyleBehavior<TComponent, TBehavior>, new()
    {
        public AttachableForStyleBehavior()
        {

        }
        #region IsEnabledForStyle

        public static DependencyProperty IsEnabledForStyleProperty =
            DependencyProperty.RegisterAttached(nameof(IsEnabledForStyle), typeof(bool),
            typeof(AttachableForStyleBehavior<TComponent, TBehavior>), new FrameworkPropertyMetadata(false, OnIsEnabledForStyleChanged));

        public bool IsEnabledForStyle
        {
            get => (bool)GetValue(IsEnabledForStyleProperty);
            set => SetValue(IsEnabledForStyleProperty, value);
        }

        private static void OnIsEnabledForStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement uie = d as UIElement;

            if (uie != null)
            {
                BehaviorCollection behColl = Interaction.GetBehaviors(uie);
                TBehavior existingBehavior = behColl.FirstOrDefault(b => b.GetType() ==
                      typeof(TBehavior)) as TBehavior;

                if ((bool)e.NewValue == false && existingBehavior != null)
                {
                    behColl.Remove(existingBehavior);
                }
                else if ((bool)e.NewValue == true && existingBehavior == null)
                {
                    behColl.Add(new TBehavior());
                }
            }
        }

        #endregion IsEnabledForStyle
    }
}
