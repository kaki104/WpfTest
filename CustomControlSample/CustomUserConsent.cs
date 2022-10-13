using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControlSample
{
    /// <summary>
    /// 사용자 동의 - CustomControl
    /// </summary>
    [TemplatePart(Name = _partSubmit, Type = typeof(Button))]
    [TemplatePart(Name = _partExit, Type = typeof(Button))]
    public class CustomUserConsent : Control, IDisposable
    {
        private const string _partSubmit = "PART_Submit";
        private const string _partExit = "PART_Exit";

        private Button? _submitButton;
        private Button? _exitButton;
        private bool disposedValue;

        static CustomUserConsent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomUserConsent), new FrameworkPropertyMetadata(typeof(CustomUserConsent)));
        }

        public bool IsUserConsent
        {
            get => (bool)GetValue(IsUserConsentProperty);
            set => SetValue(IsUserConsentProperty, value);
        }

        /// <summary>
        /// 사용자 동의 여부 - DP
        /// </summary>
        public static readonly DependencyProperty IsUserConsentProperty =
            DependencyProperty.Register(nameof(IsUserConsent), typeof(bool), typeof(CustomUserConsent), new PropertyMetadata(false));

        /// <summary>
        /// 팝업 닫기 커맨드 - 생성시 할당됨
        /// </summary>
        public ICommand? ClosePopupCommand { get; set; }

        public override void OnApplyTemplate()
        {
            _submitButton = GetTemplateChild(_partSubmit) as Button;
            _exitButton = GetTemplateChild(_partExit) as Button;
            if (_submitButton == null || _exitButton == null)
            {
                throw new NullReferenceException($"{_partSubmit} and {_partExit} button cannot be null");
            }
            _submitButton.Click += SubmitButton_Click;
            _exitButton.Click += ExitButton_Click;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClosePopupCommand != null)
            {
                ClosePopupCommand.Execute(false);
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClosePopupCommand != null)
            {
                ClosePopupCommand.Execute(IsUserConsent);
            }
        }
        /// <summary>
        /// Dispose pattern
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_submitButton != null)
                    {
                        _submitButton.Click -= SubmitButton_Click;
                        _submitButton = null;
                    }
                    if (_exitButton != null)
                    {
                        _exitButton.Click -= ExitButton_Click;
                        _exitButton = null;
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CustomUserConsent()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
