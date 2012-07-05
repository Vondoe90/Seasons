using System;
using CryEngine;

namespace CryGameCode.Seasons
{
	[Entity(Category = "Seasons", Icon = "Seed.bmp")]
	public class SeasonManager : Entity
	{
		public static DateTime TimeInfo { get; private set; }
		public static SeasonManager Instance { get; private set; }

		public static Season Season
		{
			get
			{
				var day = TimeInfo.DayOfYear;

				if(day >= 80 && day < 172)
					return Season.Spring;
				if(day >= 172 && day < 266)
					return Season.Summer;
				if(day >= 266 && day < 355)
					return Season.Autumn;

				return Season.Winter;
			}
		}

		[EditorProperty(Min = 0, Max = int.MaxValue)]
		public float Speed { get; set; }

		[EditorProperty(Min = 1, Max = 31)]
		public int StartDay { get; set; }

		[EditorProperty(Min = 1, Max = 12)]
		public int StartMonth { get; set; }

		[EditorProperty(Min = 0, Max = 10000)]
		public int StartYear { get; set; }

		[EditorProperty(Min = 0, Max = 23)]
		public float ForceUpdatesFrom { get; set; }

		[EditorProperty(Min = 1, Max = 24)]
		public float ForceUpdatesTo { get; set; }

		[EditorProperty]
		public bool ResetPerTest { get; set; }

		protected override void OnReset(bool enteringGame)
		{
			if(Instance != null && Instance != this)
				throw new Exception("Only one SeasonManager instance should exist per level.");

			TimeInfo = new DateTime(StartYear, StartMonth, StartDay);

			Instance = this;

			ReceiveUpdates = true;
		}

		public override void OnUpdate()
		{
			TimeInfo = TimeInfo.AddSeconds(Time.DeltaTime * Speed);

			// FIXME: I get really weird performance issues outside of certain hours with forced ToD updates - Ruan
			// Temp fix 'cause it's needed to get the sun pos to update properly
			var cetime = TimeInfo.Hour + (TimeInfo.Minute / 60f);
			TimeOfDay.ForceUpdates = cetime >= ForceUpdatesFrom && cetime < ForceUpdatesTo;

			TimeOfDay.Hour = TimeInfo.Hour;
			TimeOfDay.Minute = TimeInfo.Minute;
		}
	}

	[FlowNode(UICategory = "Seasons", Name = "TimeInfo", Category = FlowNodeCategory.Approved)]
	public class TimeNode : FlowNode
	{
		[Port]
		public OutputPort<int> Month { get; set; }

		[Port]
		public OutputPort<string> TimeString { get; set; }

		[Port]
		public OutputPort<float> Alpha { get; set; }

		[Port(Name = "Activate")]
		public void Test()
		{
			var time = SeasonManager.TimeInfo;
			Month.Activate(time.Month);
			TimeString.Activate(string.Format("Time: {0}\nDate: {1}\nSeason: {2}\nYear: {3}", time.ToString("HH:mm"), time.ToString("MMMM d (ddd)"), SeasonManager.Season, time.ToString("yyyy")));
		}
	}

	public enum Season
	{
		Winter,
		Spring,
		Summer,
		Autumn
	}
}