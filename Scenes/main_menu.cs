using Godot;
using System;

public partial class main_menu : Node
{
	Button level1, level2;
	public override void _Ready()
	{
		level1 = GetNode<Button>("Level1");
		level2 = GetNode<Button>("Level2");
	}

	private void level1Pressed() {
		GetTree().ChangeSceneToFile("res://Scenes/Levels/level1.tscn");
	}
	private void level2Pressed() {
		GetTree().ChangeSceneToFile("res://Scenes/Levels/level2.tscn");
	}
}
