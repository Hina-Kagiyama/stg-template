using Godot;
using System;

public partial class TitleScene : ToplevelSceneBase
{
	public override void _Ready()
	{
		base._Ready();
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("toggleMenu"))
			ExitBtnPressed();
		base._Process(delta);
	}

	public void NewStartBtnPressed() { }
	public void ContinueBtnPressed() { }
	public void MusicRoomBtnPressed() { }
	public void StatisticsBtnPressed() { }
	public void ReplayBtnPressed() { }
	public void ExitBtnPressed()
	{
		father().ProgramExit();
	}
}
