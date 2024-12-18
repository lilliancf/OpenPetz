using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Ball : Node2D
{
	private MeshInstance2D meshInstance;
	public ImmediateMesh immediateMesh;
	public ShaderMaterial material;

	private bool _queueRedraw = true;

	private Texture2D _texture;
	//public Texture2D Texture {  
	//	get => _texture;
	//	set
	//	{
 //           material.SetShaderParameter("tex", value);
 //           _texture = value;
	//		_queueRedraw = true;
	//	}
	//}
	public Texture2D palette;

	public int radius;
	public int color_index;
	public int fuzz;
	public int outline_width;
	public int outline_color;

	public Ball()
	{
		//immediateMesh = new ImmediateMesh();
	}

	public Ball(Texture2D texture, Texture2D palette, int radius, int color_index, int fuzz, int outline_width, int outline_color)
	{
		_texture = texture;
		this.palette = palette;
		this.radius = radius;
		this.color_index = color_index;
		this.fuzz = fuzz;
		this.outline_width = outline_width;
		this.outline_color = outline_color;

		//immediateMesh = new ImmediateMesh();
	}

	public Ball(Texture2D texture, int radius, int color_index, int fuzz, int outline_width, int outline_color)
	{
		_texture = texture;
		this.palette = GD.Load<Texture2D>("res://pet/data/textures/petzpalette.png");
		this.radius = radius;
		this.color_index = color_index;
		this.fuzz = fuzz;
		this.outline_width = outline_width;
		this.outline_color = outline_color;

		//immediateMesh = new ImmediateMesh();
	}

	public override void _Ready()
	{
		//meshInstance = new MeshInstance2D();
		//AddChild(meshInstance);

		//immediateMesh = new ImmediateMesh();
		//meshInstance.Mesh = immediateMesh;

		// need to copy material for each ball or else they overwrite eachother's parameters.
		// this is really inefficent and we'll need to change this at some point but that means rewriting the shader so ¯\_(ツ)_/¯ 
		//material = (ShaderMaterial)GD.Load<ShaderMaterial>("res://shaders/ball_shader.tres").Duplicate(true);

		//material = (ShaderMaterial)GD.Load<ShaderMaterial>("res://shaders/ball_shader.tres");



		//material.SetShaderParameter("fuzz", fuzz);
		//material.SetShaderParameter("radius", radius);
		//material.SetShaderParameter("outline_width", outline_width);

		//material.SetShaderParameter("color_index", color_index);
		//material.SetShaderParameter("outline_color", outline_color);

		//material.SetShaderParameter("tex", _texture);
		//material.SetShaderParameter("palette", palette);

		//material.SetShaderParameter("center", this.GlobalPosition);
	}

	public ImmediateMesh setupMesh(ImmediateMesh mesh, ShaderMaterial material)
	{
		material.SetShaderParameter("fuzz", fuzz);
		material.SetShaderParameter("radius", radius);
		material.SetShaderParameter("outline_width", outline_width);

		material.SetShaderParameter("color_index", color_index);
		material.SetShaderParameter("outline_color", outline_color);

		material.SetShaderParameter("tex", _texture);
		material.SetShaderParameter("palette", palette);

		material.SetShaderParameter("center", this.GlobalPosition);

		mesh.ClearSurfaces();
		mesh.SurfaceBegin(Mesh.PrimitiveType.Triangles);

		drawQuad(radius + fuzz, mesh);

		mesh.SurfaceEnd();
		mesh.SurfaceSetMaterial(0, material);

		return mesh;
	}

	public override void _Process(double delta)
	{
		//if (_queueRedraw)
		//{
  //          QueueRedraw();
		//	//_queueRedraw = false;
  //      }
	}


 //   public override void _Draw()
	//{
 //       material.SetShaderParameter("center", this.GlobalPosition);

 //       immediateMesh.ClearSurfaces();
	//	immediateMesh.SurfaceBegin(Mesh.PrimitiveType.Triangles);

	//	drawQuad(radius + fuzz);

	//	immediateMesh.SurfaceEnd();

	//	immediateMesh.SurfaceSetMaterial(0, material);
	//	meshInstance.Material = material;
	//}

	private void drawQuad(int size, ImmediateMesh mesh)
	{
		Vector3 bottomLeft = new Vector3(-1 * size, -1 * size, 0);
		Vector3 topLeft = new Vector3(-1 * size, size, 0);
		Vector3 topRight = new Vector3(size, size, 0);
		Vector3 bottomRight = new Vector3(size, -1 * size, 0);


		mesh.SurfaceSetUV(new Vector2(0, 1));
		mesh.SurfaceAddVertex(bottomLeft);

		mesh.SurfaceSetUV(new Vector2(0, 0));
		mesh.SurfaceAddVertex(topLeft);

		mesh.SurfaceSetUV(new Vector2(1, 1));
		mesh.SurfaceAddVertex(topRight);


		mesh.SurfaceSetUV(new Vector2(0, 1));
		mesh.SurfaceAddVertex(bottomRight);

		mesh.SurfaceSetUV(new Vector2(0, 0));
		mesh.SurfaceAddVertex(bottomLeft);

		mesh.SurfaceSetUV(new Vector2(1, 1));
		mesh.SurfaceAddVertex(topRight);
	}


}
