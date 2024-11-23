using UnityEngine;

namespace Additions.Extensions
{
	public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
	{
		private static T _instance;

		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					var newObject = new GameObject(typeof(T).ToString());
					_instance = newObject.AddComponent<T>();
					_instance.Init();
				}

				return _instance;
			}
		}

		protected virtual void Init()
		{
		}
	}
}