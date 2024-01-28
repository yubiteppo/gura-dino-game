using Godot;
using System;

public partial class cactus_0 : Node2D
{
	//private Sprite2D _cactus;
	//private float _moveAmount;
	//private Vector2 _position, _originalPosition;
	//private int _numCacti, _minVal, _maxVal;
	//private Random _random;
	//
	//private void Move()
	//{
		//float endPosition = -2000;
		//if (_cactus.Position.X < endPosition)
		//{
			//int newStartingX = _random.Next(1, 2500);
			//GD.Print(newStartingX);
			//Vector2 newPosition = new Vector2(newStartingX, _originalPosition.Y);
			//_position = newPosition;
			//_cactus.Position = _position;
			//_numCacti = _random.Next(_minVal, _maxVal);
		//}
		//else
		//{
			//_position.X += _moveAmount;
			//_cactus.Position = _position;
		//}
	//}
	//
	//// Called when the node enters the scene tree for the first time.
	//public override void _Ready()
	//{
		//_random = new();
		//_minVal = 1;
		//_maxVal = 4;
		//_numCacti = _random.Next(_minVal, _maxVal);
		//_cactus = GetNode<Sprite2D>($"Sprite2D");
		//_moveAmount = -12.5f;
		//_position = new Vector2(_cactus.Position.X, _cactus.Position.Y);
		//_originalPosition = new Vector2(_cactus.Position.X, _cactus.Position.Y);
	//}
//
	//// Called every frame. 'delta' is the elapsed time since the previous frame.
	//public override void _Process(double delta)
	//{
		//Move();
	//}
}
