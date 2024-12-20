using Godot;
using System;
using System.Collections.Generic;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

public partial class Pet : Node2D
{

	//public Stack<Kaitai.Scp.Action> actionStack = new Stack<Kaitai.Scp.Action>();
	//public Kaitai.Scp.Action lastScpAction;
	//public uint currentScpState; 

	// Called when the node enters the scene tree for the first time.

	//test
	public override void _Ready()
	{
		World.pets.Add(this);

		//var bitmap = new BMP();
		//bitmap.LoadFile("res://pet/data/textures/hair6.bmp");

		//Texture2D tex = bitmap.GetData();

		Texture2D texture = GD.Load<Texture2D>("res://pet/data/textures/hair6.bmp");
		Texture2D palette = GD.Load<Texture2D>("res://pet/data/textures/petzpalette.png");

		Ball ball = new Ball(texture, palette, 50, 105, 3, 5, 5);
		AddChild(ball);

		ball.GlobalPosition = new Vector2(100, 100);

		Ball ball2 = new Ball(texture, palette, 50, 105, 3, 5, 5);
		AddChild(ball2);

		ball2.GlobalPosition = new Vector2(200, 200);
	}

	public override void _ExitTree()
	{
		World.pets.Remove(this);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

}
