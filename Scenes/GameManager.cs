using Godot;
using System;

public partial class GameManager : Node
{
	int points = 0;
	Label pointsLabel;
    public override void _Ready()
    {
        pointsLabel = GetNode<Label>("%PointsLabel");
    }

    public void AddPoint() {
		points += 1;
		pointsLabel.Text = "Points: " + points.ToString();
	}
}
