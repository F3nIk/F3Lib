
namespace F3Lib.Patterns.Singleton
{
    public class SingletonObject<Type> where Type : SingletonObject<Type>
    {
		private static SingletonObject<Type> _instance;

		public static SingletonObject<Type> Instance
        {
			get => _instance ?? new SingletonObject<Type>();
        }

		protected SingletonObject() { }
	}
}