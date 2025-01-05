using Godot;
using System;

public partial class LoadScene : ToplevelSceneBase
{
	private AnimatedSprite2D digit1;
	private AnimatedSprite2D digit2;
	[Export] public float percentage = 0;
	public override void _Ready()
	{
		digit1 = GetNode<AnimatedSprite2D>("Digit1");
		digit2 = GetNode<AnimatedSprite2D>("Digit2");
		base._Ready();
	}

	public override void _Process(double delta)
	{
		var b1 = (int)(percentage % 10f);
		var b10 = (int)(percentage % 100f - b1) / 10;
		digit1.Frame = b10;
		digit2.Frame = b1;
		base._Process(delta);
	}
}
