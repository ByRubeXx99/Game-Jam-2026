using System;

namespace Mold
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Engine e = new Engine();
			e.Run( new MoldGame());
		}
	}
}
