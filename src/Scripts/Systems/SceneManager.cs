using Godot;
using System;

public partial class SceneManager : Node2D
{
	private PackedScene titlescene_res = GD.Load<PackedScene>("res://GDSN/Scenes/title_scene.tscn");
	private PackedScene gamescene_res = GD.Load<PackedScene>("res://GDSN/Scenes/game_scene.tscn");
	private PackedScene loadscene_res = GD.Load<PackedScene>("res://GDSN/Scenes/load_scene.tscn");
	private PackedScene cutscene_res = GD.Load<PackedScene>("res://GDSN/Scenes/cut_scene.tscn");
	private PackedScene musicroomscene_res = GD.Load<PackedScene>("res://GDSN/Scenes/music_room_scene.tscn");
	private PackedScene loadoutselectscene_res = GD.Load<PackedScene>("res://GDSN/Scenes/loadout_select_scene.tscn");

	private TitleScene _titleScene;
	private GameScene _gameScene;
	private LoadScene _loadScene;
	private CutScene _cutScene;
	private MusicRoomScene _musicRoomScene;
	private LoadoutSelectScene _loadoutSelectScene;

	public override void _Ready()
	{
		_titleScene = titlescene_res.Instantiate<TitleScene>();
		_gameScene = gamescene_res.Instantiate<GameScene>();
		_loadScene = loadscene_res.Instantiate<LoadScene>();
		_cutScene = cutscene_res.Instantiate<CutScene>();
		_musicRoomScene = musicroomscene_res.Instantiate<MusicRoomScene>();
		_loadoutSelectScene = loadoutselectscene_res.Instantiate<LoadoutSelectScene>();
		AddChild(_titleScene);
	}

	public override void _Process(double delta)
	{
	}

	public void ProgramExit()
	{
		// some saving jobs should be done here
		GetTree().Quit();
	}
}
