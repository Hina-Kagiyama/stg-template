using Godot;
using System;

public partial class ToplevelSceneBase : Node2D
{
	protected SceneManager father()
	{
		return GetParent<SceneManager>();
	}
	
	public override void _Ready()
	{
		ProcessMode = ProcessModeEnum.Pausable;
	}

	public override void _Process(double delta)
	{
	}
}
