using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using WpfLocalization.Strings;

namespace WpfLocalization
{
    /// <summary>
    /// 다이나믹 리소스 - 모든 택스트 리소스는 여기를 통해서 출력됨
    /// </summary>
    public class DynamicResource : DynamicObject
    {
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
            _resourceManager = new ResourceManager(typeof(Resource));
        }

        #region 기본 기능

        /// <summary>
        /// 프로퍼티로 호출
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string this[string id]
        {
            get
            {
                //1. 리소스에서 값 조회
                if (string.IsNullOrEmpty(id)) return null;
                string str = _resourceManager.GetString(id, _clutureInfo);
                if (string.IsNullOrEmpty(str))
                //2. 없으면 키 반환
                {
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

        #endregion
        /// <summary>
        /// 클래스 네임
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 리소스 딕셔너리
        /// </summary>
        private IDictionary<KeyValuePair<string, string>, string> ResourceDictionaryUsedByClass { get; }
            = new Dictionary<KeyValuePair<string, string>, string>();

        /// <summary>
        /// 클래스에서 사용하는 리소스 사전에 추가
        /// </summary>
        /// <param name="className"></param>
        /// <param name="resourceKey"></param>
        private void AddResourceDictionary(string className, string resourceKey)
        {
            KeyValuePair<string, string> key = new KeyValuePair<string, string>(className ?? "public", resourceKey);
            if (ResourceDictionaryUsedByClass.ContainsKey(key))
            {
                return;
            }

            ResourceDictionaryUsedByClass.Add(new KeyValuePair<KeyValuePair<string, string>, string>(key, resourceKey));
        }

        /// <summary>
        /// 클래스에서 사용하는 리소스 사전 조회
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public IList<string> GetResourceDictionary(string className)
        {
            List<string> returnValues = (from item in ResourceDictionaryUsedByClass
                                         where item.Key.Key == className
                                         select item.Value).ToList();
            return returnValues;
        }

        /// <summary>
        /// 런타임 언어 변경
        /// </summary>
        /// <param name="languageCode"></param>
        public void ChangeLanguage(string languageCode)
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
        }
    }
}
