using DependencyInversionSample.Common.Strings;
using System;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Windows;
using System.Windows.Markup;

namespace DependencyInversionSample.Common
{
    /// <summary>
    /// String Resource 사용 클래스
    /// </summary>
    public class DynamicResource : DynamicObject, IDynamicResource
    {
        /// <summary>
        /// 언어 변경 이벤트
        /// </summary>
        public event EventHandler<string> LanguageChanged;
        /// <summary> 
        /// 윈도우 리소스로더 
        /// </summary> 
        private readonly ResourceManager _resourceManager;
        private CultureInfo _clutureInfo;

        /// <summary> 
        /// 생성자 
        /// </summary> 
        public DynamicResource()
        {
            _resourceManager = new ResourceManager(typeof(CommonResource));
        }

        /// <summary> 
        /// 프로퍼티로 호출 
        /// </summary> 
        /// <param name="id"></param> 
        /// <returns></returns> 
        public virtual string this[string id]
        {
            get
            {
                //1. 리소스에서 값 조회
                if (string.IsNullOrEmpty(id)) return null;
                string str = _resourceManager.GetString(id, _clutureInfo);
                if (string.IsNullOrEmpty(str))
                {
                    //2. 없으면 키 반환
                    str = id;
                }
                return str;
            }
        }

        /// <summary> 
        /// 이름으로 호출 
        /// </summary> 
        /// <param name="binder"></param> 
        /// <param name="result"></param> 
        /// <returns></returns> 
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string id = binder.Name;
            string str = _resourceManager.GetString(id, _clutureInfo);
            if (string.IsNullOrEmpty(str))
            {
                str = id;
            }
            result = str;
            return true;
        }

        /// <summary> 
        /// 런타임 언어 변경 
        /// </summary> 
        /// <param name="languageCode"></param> 
        public virtual void ChangeLanguage(string languageCode)
        {
            _clutureInfo = new CultureInfo(languageCode);
            Thread.CurrentThread.CurrentCulture = _clutureInfo;
            Thread.CurrentThread.CurrentUICulture = _clutureInfo;
            //윈도우의 언어코드 변경
            foreach (Window window in Application.Current.Windows.Cast<Window>())
            {
                if (!window.AllowsTransparency)
                {
                    window.Language = XmlLanguage.GetLanguage(_clutureInfo.Name);
                }
            }
            if (LanguageChanged != null)
            {
                LanguageChanged.Invoke(this, _clutureInfo.Name);
            }
        }
    }
}
