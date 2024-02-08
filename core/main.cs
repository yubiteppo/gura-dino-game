using Godot;
using System;

public partial class main : Node2D
{	
	private Score _score;
	private int _prevScore;
	private cactus _cactus;
	private gura _gura;
	private bool _isGameOver;
	
	private void SenseCollision()
	{
		if (_gura.HasCollided())
		{
			_cactus.GameOver();
			_score.SetScorePaused();
			_isGameOver = true;
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_score = GetNode<Score>($"ColorRect/Score");
		_prevScore = _score.GetScore();
		_cactus = GetNode<cactus>($"Cactus");
		_gura = GetNode<gura>($"Gura");
		_isGameOver = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		SenseCollision();
		
		if (_isGameOver && Input.IsActionJustPressed("jump"))
		{
			_gura.Reset();
			_cactus.Reset();
			_score.Reset();
			_isGameOver = false;
		}
		
		int currentScore = _score.GetScore();
		if (currentScore - _prevScore >= 100)
		{
			_cactus.IncreaseSpeed();
			_prevScore = currentScore;
		}
		
		if (Input.IsActionJustPressed("exit"))
		{	
			DisplayServer.WindowSetMode((DisplayServer.WindowMode)2);
		}
		
		if (Input.IsActionJustPressed("toggle_fullscreen"))
		{
			if ((int)DisplayServer.WindowGetMode() == 3)
			{
				DisplayServer.WindowSetMode((DisplayServer.WindowMode)2);
			}
			else
			{
				DisplayServer.WindowSetMode((DisplayServer.WindowMode)3);
			}
		}
	}
}
