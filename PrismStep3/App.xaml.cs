using Prism.Ioc;
using PrismStep3.Views;
using System.Windows;

namespace PrismStep3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Transient 등록
            containerRegistry.Register<IPerson, Person>();

            //Singleton 등록
            //처음 Person을 호출하면, Person 인스턴스를 하나 만들고, 다음 호출부터는 그 인스턴스를 반환
            //containerRegistry.RegisterSingleton<Person>();
            //처음 Person을 호출하면, 미리 정의된 Person 인스턴스를 만들고, 다음 호출부터는 그 인스턴스를 반환
            containerRegistry.RegisterSingleton<Person>(() => new Person { Id = 100, Name = "kaki104", Sex = true });
            //처음 Person을 호출하면, container를 이용해서 작업을 진행할 수 있습니다. 다만, 아래 코드는 오류가 발생합니다. 재귀호출이 되어버려서..
            //containerRegistry.RegisterSingleton<Person>(container => container.Resolve<Person>());

            //생성된 인스턴스 등록
            var kaki105 = new Person { Id = 1, Name = "kaki105", Sex = false };
            //인스턴스를 생성하고, 식별자를 이용해서 여러개 등록할 수 있습니다.
            containerRegistry.RegisterInstance(kaki105, "kaki105");
            containerRegistry.RegisterInstance(kaki105, "kaki106");
        }
    }
}
