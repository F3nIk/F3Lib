
namespace F3Lib.Patterns.Singleton
{

    public class SingletonObject<Type> where Type : SingletonObject<Type>
    {
        private static SingletonObject<Type> _instance;

        public static SingletonObject<Type> Instance => _instance;

        protected SingletonObject()
        {
            if (_instance != null) throw new System.InvalidOperationException();

            _instance = this;
        }
    }
}