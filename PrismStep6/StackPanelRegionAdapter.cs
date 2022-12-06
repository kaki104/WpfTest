using Prism.Ioc;
using Prism.Regions;
using PrismStep6.Views;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PrismStep6
{
    /// <summary>
    /// StackPanel RegionAdapter
    /// </summary>
    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        private IContainerProvider _containerProvider;
        /// <summary>
        /// 리즌명
        /// </summary>
        private string _regionName;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="regionBehaviorFactory"></param>
        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory, IContainerProvider containerProvider)
            : base(regionBehaviorFactory)
        {
            _containerProvider = containerProvider;
        }
        /// <summary>
        /// 논리적 Region과 물리적 Region간의 연결 관계 설정
        /// </summary>
        /// <param name="region"></param>
        /// <param name="regionTarget"></param>
        /// <exception cref="NotImplementedException"></exception>
        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            //리즌 이름 입력
            _regionName = region.Name;
            region.Views.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (FrameworkElement element in e.NewItems)
                        {
                            //문자열을 전달하면서 Injection하기 - 리즌명 입력
                            var regionBase = _containerProvider.Resolve<RegionBase>((typeof(string), _regionName));
                            regionBase.RegionBaseContent.Content = element;
                            _ = regionTarget.Children.Add(regionBase);
                        }
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (FrameworkElement element in e.OldItems)
                        {
                            var removeItem = regionTarget.Children.OfType<RegionBase>()
                                            .FirstOrDefault(rb => rb.RegionBaseContent.Content == element);
                            if (removeItem != null)
                            {
                                regionTarget.Children.Remove(removeItem);
                            }
                        }
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        break;
                    case NotifyCollectionChangedAction.Move:
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        break;
                }
            };
        }
        /// <summary>
        /// 논리적 Region 생성
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected override IRegion CreateRegion()
        {
            //StackPanel에는 모든 컨텐츠가 다 보이기 때문에 전체 ActiveRegion으로 생성
            return new AllActiveRegion();

            //TabItem과 같은 1개만 선택되어야 하는 Region은 SingleActiveRegion으로 생성
            //return new SingleActiveRegion();
        }
    }
}
