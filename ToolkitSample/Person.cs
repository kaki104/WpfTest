using CommunityToolkit.Mvvm.ComponentModel;

namespace ToolkitSample
{
    public class Person : ObservableObject
    {
        private int _id;
        /// <summary>
        /// Id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _name;
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private bool _sex;
        /// <summary>
        /// Sex
        /// </summary>
        public bool Sex
        {
            get { return _sex; }
            set { SetProperty(ref _sex, value); }
        }
    }
}
