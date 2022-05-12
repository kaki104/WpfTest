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
        /// 공통 리소스 메니저
        /// </summary> 
        private readonly ResourceManager _resourceManager;
        protected CultureInfo ClutureInfo = new("en-US");

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
                string value = _resourceManager.GetString(id, ClutureInfo);
                if (string.IsNullOrEmpty(value))
                {
                    //2. 없으면 키 반환
                    value = id;
                }
                return value;
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
            string value = _resourceManager.GetString(id, ClutureInfo);
            if (string.IsNullOrEmpty(value))
            {
                value = id;
            }
            result = value;
            return true;
        }

        /// <summary> 
        /// 런타임 언어 변경 
        /// </summary> 
        /// <param name="languageCode"></param> 
        public virtual void ChangeLanguage(string languageCode)
        {
            ClutureInfo = new CultureInfo(languageCode);
            Thread.CurrentThread.CurrentCulture = ClutureInfo;
            Thread.CurrentThread.CurrentUICulture = ClutureInfo;
            //윈도우의 언어코드 변경
            foreach (Window window in Application.Current.Windows.Cast<Window>())
            {
                if (!window.AllowsTransparency)
                {
                    window.Language = XmlLanguage.GetLanguage(ClutureInfo.Name);
                }
            }
            if (LanguageChanged != null)
            {
                LanguageChanged.Invoke(this, ClutureInfo.Name);
            }
        }
    }
}
