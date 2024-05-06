using Godot;
using System;

public partial class collectable : Area2D
{
	GameManager gameManager;
    public override void _Ready()
    {
        gameManager = GetNode<GameManager>("%GameManager");
    }
    private void _on_body_entered(Node body) {
		if (body.Name == "Player") {
			QueueFree();
			gameManager.AddPoint();
		}
	}
}