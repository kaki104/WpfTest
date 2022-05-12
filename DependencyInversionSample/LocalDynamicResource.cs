using DependencyInversionSample.Common;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using DependencyInversionSample.Strings;

namespace DependencyInversionSample
{
    /// <summary>
    /// 로컬 String Resource 사용 클래스
    /// </summary>
    public class LocalDynamicResource : DynamicResource
    {
        /// <summary> 
        /// 로컬 리소스 메니저 
        /// </summary> 
        private readonly ResourceManager _resourceManager;

        public LocalDynamicResource() : base()
        {
            _resourceManager = new ResourceManager(typeof(LocalResource));
        }

        public override string this[string id]
        {
            get
            {
                if (string.IsNullOrEmpty(id)) return null;
                string value = _resourceManager.GetString(id, ClutureInfo);
                if (string.IsNullOrEmpty(value) == false)
                {
                    return value;
                }
                else
                {
                    return base[id];
                }
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string id = binder.Name;
            string value = _resourceManager.GetString(id, ClutureInfo);
            if (string.IsNullOrEmpty(value) == false)
            {
                result = value;
                return true;
            }
            else
            {
                return base.TryGetMember(binder, out result);
            }
        }
    }
}
