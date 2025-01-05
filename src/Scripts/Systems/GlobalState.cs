using Godot;
using System;

public class GlobalState
{
	public class LoadoutEnum
	{
		private PlayerBase player1 { set; get; }
		private PlayerBase player2 { set; get; }

		private WeaponBase weapon1 { set; get; }
		private WeaponBase weapon2 { set; get; }
	}
}
