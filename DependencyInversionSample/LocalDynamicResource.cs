using DependencyInversionSample.Common;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionSample
{
    public class LocalDynamicResource : DynamicResource
    {
        private IDictionary<string, string> _stringDic;

        public LocalDynamicResource()
            : base()
        {
            _stringDic = new Dictionary<string, string>
            {
                {"msg_local", "This is a local string" },
                {"msg_koreannotsupport", "Korean is not supported" },
            };
        }

        public override string this[string id]
        {
            get
            {
                if(_stringDic.ContainsKey(id))
                {
                    return _stringDic[id];
                }
                else
                {
                    return base[id];
                }
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if(_stringDic.ContainsKey(binder.Name))
            {
                result = _stringDic[binder.Name];
                return true;
            }
            else
            {
                return base.TryGetMember(binder, out result);
            }
        }
    }
}
