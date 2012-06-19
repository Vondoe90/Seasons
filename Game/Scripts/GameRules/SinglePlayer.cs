using CryEngine;
using CryGameCode.Entities;
using CryGameCode.Actors;

using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The campaign game mode is the base game mode
/// </summary>
namespace CryGameCode
{
	[GameRules(Default = true)]
	public class SinglePlayer : GameRules
	{
		//This is called, contrary to what you'd expect, just once, as the player persists between test sessions in the editor (ctrl+g)
		public override void OnClientConnect(int channelId, bool isReset = false, string playerName = "")
		{
			var player = Actor.Create<Player>(channelId, "Player");
			if(player == null)
			{
				Debug.Log("[SinglePlayer.OnClientConnect] Failed to create the player. Check the log for errors.");
				return;
			}
		}

		public override void OnClientDisconnect(int channelId)
		{
			Actor.Remove(channelId);
		}

		public override void OnRevive(EntityId actorId, Vec3 pos, Vec3 rot, int teamId)
		{
			Debug.LogAlways("SinglePlayer.OnRevive");
			var player = Actor.Get<Player>(actorId);

			if(player == null)
			{
				Debug.Log("[SinglePlayer.OnRevive] Failed to get the player. Check the log for errors.");
				return;
			}

			player.Init();
		}
	}
}