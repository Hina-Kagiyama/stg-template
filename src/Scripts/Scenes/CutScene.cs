using Godot;
using System;
using System.Data;
using System.Runtime.Serialization;

public partial class CutScene : ToplevelSceneBase
{
	private PackedScene tile_res = GD.Load<PackedScene>("res://GDSN/Scenes/UI/cut_scene_animated_tile.tscn");
	private Node2D[] tiles;
	private int maxI, maxJ;

	public override void _Ready()
	{
		var reference_tile = tile_res.Instantiate<Node2D>();
		var reftiletext = reference_tile.GetNode<TextureRect>("TextureRect");
		var tile_size = reftiletext.Size;
		var tile_scale = reftiletext.Scale;
		var actual_width = tile_size.X * tile_scale.X;
		var actual_height = tile_size.Y * tile_scale.Y;
		reference_tile.Free();

		maxI = Mathf.CeilToInt(GetWindow().Size.X / actual_width);
		maxJ = Mathf.CeilToInt(GetWindow().Size.Y / actual_height);
		tiles = new Node2D[maxI * maxJ];
		for (var i = 0; i < maxI; ++i)
		{
			for (var j = 0; j < maxJ; ++j)
			{
				var tmp = tile_res.Instantiate<Node2D>();
				tmp.Position = new Vector2(i * actual_width, j * actual_height);
				tmp.Visible = false;
				tiles[i * maxJ + j] = tmp;
				AddChild(tmp);
			}
		}
		base._Ready();
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
	}

	public void AniFlyInto()
	{
		for (var i = 0; i < maxI; ++i)
			for (var j = 0; j < maxJ; ++j)
			{
				var elm = tiles[i * maxJ + j];
				var tmp = elm.GetNode<AnimationPlayer>("AnimationPlayer");
				var tm = elm.GetNode<Timer>("Timer");
				tmp.SpeedScale = 4;
				tm.WaitTime = (double)((i + 1) * maxJ + (j + 1)) / (maxI * maxJ + maxI + maxJ) / 4;
				tm.OneShot = true;
				tm.Timeout += () => { tmp.Play("fly_into"); elm.Visible = true; };
				tm.Start();
			}
	}

	public void AniFlyOut()
	{
		for (var i = 0; i < maxI; ++i)
			for (var j = 0; j < maxJ; ++j)
			{
				var elm = tiles[i * maxJ + j];
				var tmp = elm.GetNode<AnimationPlayer>("AnimationPlayer");
				var tm = elm.GetNode<Timer>("Timer");
				tmp.SpeedScale = 4;
				tm.WaitTime = (double)((i + 1) * maxJ + (j + 1)) / (maxI * maxJ + maxI + maxJ) / 4;
				tm.OneShot = true;
				tm.Timeout += () => { tmp.PlayBackwards("fly_into"); elm.Visible = true; };
				tm.Start();
			}
	}
}
