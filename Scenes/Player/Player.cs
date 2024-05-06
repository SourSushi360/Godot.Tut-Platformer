using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 400.0f;
	public const float JumpVelocity = -750.0f;
	AnimatedSprite2D sprite2D;

    public override void _Ready()
    {
        sprite2D = GetNode<AnimatedSprite2D>("Sprite2D");
    }

    // Get the gravity from the project settings to be synced with RigidBody nodes.
    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		// Animations
		if (velocity.X < -1 || velocity.X > 1)
			sprite2D.Animation = "running";
		else
			sprite2D.Animation = "idle";
		// Add the gravity.
		velocity.Y += gravity * (float)delta;
		if (!IsOnFloor())
			sprite2D.Animation = "jumping";
			
		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = JumpVelocity;
			
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("left", "right", "", "");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, 50);
		}

		Velocity = velocity;
		MoveAndSlide();

		bool isLeft = velocity.X < 0;
		sprite2D.FlipH = isLeft;
	}
}
