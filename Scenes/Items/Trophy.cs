using Godot;
using System;

public partial class Trophy : Area2D
{
	[Export]
    public PackedScene targetLevel;
	public void OnBodyEntered(Node body) {
		if (body.Name == "Player") {
			GetTree().ChangeSceneToPacked(targetLevel);
		}
	}
}
