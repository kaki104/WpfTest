using System;
using System.Dynamic;

namespace DependencyInversionSample.Common
{
    /// <summary>
    /// String Resource 사용 인터페이스
    /// </summary>
    public interface IDynamicResource
    {
        string this[string id] { get; }

        event EventHandler<string> LanguageChanged;

        void ChangeLanguage(string languageCode);

        bool TryGetMember(GetMemberBinder binder, out object result);
    }
}