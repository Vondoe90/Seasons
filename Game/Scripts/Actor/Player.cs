using CryEngine;

namespace CryGameCode.Actors
{
	[Actor(useMonoActor = false)]
	class Player : Actor
	{
		public void Init()
		{
			View.Active.FoV = Math.DegreesToRadians(60);
		}
	}
}
