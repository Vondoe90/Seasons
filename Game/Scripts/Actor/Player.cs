using CryEngine;

namespace CryGameCode.Actors
{
	[Actor(useMonoActor = false)]
	class Player : Actor
	{
		public void Init()
		{
			View.Active.FieldOfView = Math.DegreesToRadians(60);
		}
	}
}
