using System;
using System.Dynamic;

namespace DependencyInversionSample.Common
{
    /// <summary>
    /// String Resource 사용 인터페이스
    /// </summary>
    public interface IDynamicResource
    {
        /// <summary>
        /// XAML에서 사용
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string this[string id] { get; }
        /// <summary>
        /// 언어 변경 이벤트
        /// </summary>
        event EventHandler<string> LanguageChanged;
        /// <summary>
        /// 언어 변경
        /// </summary>
        /// <param name="languageCode"></param>
        void ChangeLanguage(string languageCode);
        /// <summary>
        /// Code에서 사용
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        bool TryGetMember(GetMemberBinder binder, out object result);
    }
}