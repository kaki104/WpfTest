using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewSample
{
    public class ListViewGroupViewModel : ObservableObject
    {
        private IList<Animal> _animals;
        /// <summary>
        /// 동물들
        /// </summary>
        public IList<Animal> Animals
        {
            get { return _animals; }
            set { SetProperty(ref _animals, value); }
        }

        public ListViewGroupViewModel()
        {
            Animals = new List<Animal>
            {
                new Animal { IsChecked=true, Name = "Cat1",  Type = "animal", ImagePath = @"Images\cat.png"},
                new Animal { IsChecked=true, Name = "Fish1",  Type = "fish", ImagePath = @"Images\fish.png"},
                new Animal { IsChecked=false, Name = "Flower1",  Type = "plant", ImagePath = @"Images\flower.jpg"},
                new Animal { IsChecked=false, Name = "Dog2",  Type = "animal", ImagePath = @"Images\dog.png"},
                new Animal { IsChecked=true, Name = "Fish2",  Type = "fish", ImagePath = @"Images\fish.png"},
                new Animal { IsChecked=false, Name = "Flower2",  Type = "plant", ImagePath = @"Images\flower.jpg"},
                new Animal { IsChecked=true, Name = "Cat3",  Type = "animal", ImagePath = @"Images\cat.png"},
                new Animal { IsChecked=true, Name = "Fish3",  Type = "fish", ImagePath = @"Images\fish.png"},
                new Animal { IsChecked=false, Name = "Flower3",  Type = "plant", ImagePath = @"Images\flower.jpg"},
                new Animal { IsChecked=false, Name = "Dog4",  Type = "animal", ImagePath = @"Images\dog.png"},
                new Animal { IsChecked=true, Name = "Fish4",  Type = "fish", ImagePath = @"Images\fish.png"},
                new Animal { IsChecked=false, Name = "Flower4",  Type = "plant", ImagePath = @"Images\flower.jpg"},
                new Animal { IsChecked=true, Name = "Cat5",  Type = "animal", ImagePath = @"Images\cat.png"},
                new Animal { IsChecked=true, Name = "Fish5",  Type = "fish", ImagePath = @"Images\fish.png"},
                new Animal { IsChecked=false, Name = "Flower5",  Type = "plant", ImagePath = @"Images\flower.jpg"},
            };
        }
    }
}
