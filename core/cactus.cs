using Godot;
using System;

public partial class cactus : Node2D
{
	private cactus_0 _cactus0;
	private cactus_1 _cactus1;
	private cactus_2 _cactus2;
	
	private int _minVal, _maxVal;
	private float _moveAmount;
	private Vector2 _position, _originalPosition;
	
	private Random _random;
	
	private void Move()
	{
		float endPosition = -2000;
		if (this.Position.X <= endPosition)
		{
			int newStartingX = _random.Next(1200, 2501);
			Vector2 newPosition = new Vector2(newStartingX, _originalPosition.Y);
			_position = newPosition;
			this.Position = _position;
			
			int thisCactus = _random.Next(0, 3);
			
			_cactus0.Hide();
			_cactus1.Hide();
			_cactus2.Hide();
			
			if (thisCactus == 0)
			{
				_cactus0.Show();
			}
			else if (thisCactus == 1)
			{
				_cactus1.Show();
			}
			else
			{
				_cactus2.Show();
			}
		}
		else
		{
			_position.X += _moveAmount;
			this.Position = _position;
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_random = new();
		_cactus0 = GetNode<cactus_0>($"Cactus0");
		_cactus1 = GetNode<cactus_1>($"Cactus1");
		_cactus2 = GetNode<cactus_2>($"Cactus2");
		
		_minVal = 1;
		_maxVal = 4;
		_moveAmount = -12.5f;
		
		_position = new Vector2(this.Position.X, this.Position.Y);
		_originalPosition = new Vector2(this.Position.X, this.Position.Y);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Move();
	}
}
