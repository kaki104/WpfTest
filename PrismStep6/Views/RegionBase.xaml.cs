using Prism.Regions;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PrismStep6.Views
{
    /// <summary>
    /// RegionBase 컨트롤
    /// </summary>
    public partial class RegionBase : UserControl
    {
        /// <summary>
        /// 리즌 메니저
        /// </summary>
        private readonly IRegionManager _regionManager;
        /// <summary>
        /// 리즌 이름
        /// </summary>
        private readonly string _regionName;

        public RegionBase()
        {
            InitializeComponent();
        }

        public RegionBase(IRegionManager regionManager, string regionName) : this()
        {
            _regionManager = regionManager;
            _regionName = regionName;
        }
        /// <summary>
        /// 닫기 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //리즌 찾기
            IRegion region = _regionManager.Regions[_regionName];
            if (region == null)
            {
                return;
            }
            //리즌에서 제거할 뷰 찾기
            object removeItem = region.Views.FirstOrDefault(v => v.Equals(RegionBaseContent.Content));
            if (removeItem != null)
            {
                //뷰 제거 - 이렇게해야 case NotifyCollectionChangedAction.Remove: 이벤트가 발생합니다.
                region.Remove(removeItem);
            }
        }
    }
}
