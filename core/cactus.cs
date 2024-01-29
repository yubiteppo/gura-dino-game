using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class cactus : Node2D
{
	private cactus_0 _cactus0;
	private cactus_1 _cactus1;
	private cactus_2 _cactus2;
	
	private List<general_cactus> _cactusList;
	
	private int _minVal, _maxVal;
	private float _moveAmount, _speedCap, _endPoint, _spawnPoint;
	private Vector2 _position, _originalPosition;
	
	private Random _random;
	
	private void Move()
	{
		if (_cactusList.Count > 0)
		{
			for (int i = _cactusList.Count - 1; i >= 0; --i)
			{
				general_cactus currentCactus = _cactusList[i];
				float currentCactusPosition = currentCactus.GetXPosition();
				if (currentCactusPosition <= _endPoint)
				{
					_cactusList.RemoveAt(i);
					currentCactus.QueueFree();
					//currentCactus.Reset();
					//currentCactus.SetXPosition(_originalPosition.X + _random.Next(0, 500));
				}
				else if (currentCactusPosition <= _spawnPoint && !currentCactus.HasSpawnedCactus())
				{
					int whichCactus = _random.Next(0, 3);
					string whichCactusString = "./Cactus" + whichCactus.ToString();
					general_cactus dup = GetNode<general_cactus>(whichCactusString).DuplicateCactus();
					AddChild(dup);
					dup.SetXPosition(_random.Next(0, 1200));
					_cactusList.Add(dup);
					currentCactus.SetHasSpawnedCactusTrue();
				}
				else
				{
					currentCactus.UpdateXPosition(_moveAmount);
				}
			}
		}
		else
		{
			int whichCactus = _random.Next(0, 3);
			string whichCactusString = "./Cactus" + whichCactus.ToString();
			general_cactus dup = GetNode<general_cactus>(whichCactusString).DuplicateCactus();
			AddChild(dup);
			_cactusList.Add(GetNode<general_cactus>(whichCactusString));
		}
	}
	
	public void IncreaseSpeed()
	{
		float speedDecrement = 1.0f;
		if (_moveAmount - speedDecrement >= _speedCap)
		{
			_moveAmount -= speedDecrement;
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_random = new();
		_cactus0 = GetNode<cactus_0>($"Cactus0");
		_cactus1 = GetNode<cactus_1>($"Cactus1");
		_cactus2 = GetNode<cactus_2>($"Cactus2");
		
		general_cactus dup0 = _cactus0.DuplicateCactus();
		AddChild(dup0);
		
		_cactusList = new();
		_cactusList.Add(dup0);
		//_cactusList.Add(GetNode<general_cactus>($"Cactus0"));
		
		_minVal = 1;
		_maxVal = 4;
		_moveAmount = -12.5f;
		_speedCap = -35.0f;
		
		_position = new Vector2(this.Position.X, this.Position.Y);
		_originalPosition = new Vector2(this.Position.X, this.Position.Y);
		
		_endPoint = -(_originalPosition.X + 50);
		_spawnPoint = -900;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Move();
	}
}
