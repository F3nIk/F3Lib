using UnityEngine;

namespace F3Lib.Patterns.Singleton
{
    public class SingletonMono<Type> : MonoBehaviour where Type : SingletonMono<Type>
	{
		private static SingletonMono<Type> _instance;

		public static SingletonMono<Type> Instance
		{
			get => _instance ?? new SingletonMono<Type>();
		}

		protected SingletonMono() { }

	}
}