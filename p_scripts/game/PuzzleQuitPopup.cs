namespace Com.LaytonCommunity.RavensCurse.Game;

public partial class PuzzleQuitPopup : Ui.UiBase
{
	// Constants
	//public const string ANIM_FADE_OUT = "ui_title/fade_out";
	
	// Enums
	
	// Signal
	
	// Export variables
	[ExportGroup("Imports")]
	[Export(PropertyHint.File,"*.tscn")] private string sceneLocation;
	[Export] protected TextureButton buttonQuitYes;
	[Export] protected TextureButton buttonQuitNo;
	[Export] protected AudioStreamPlayer buttonQuitSfx;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		buttonQuitYes.Pressed += OnButtonQuitYes;
		buttonQuitNo.Pressed += OnButtonQuitNo;
	}
	
	private void OnButtonQuitYes()
	{
		buttonQuitYes.Pressed -= OnButtonQuitYes;
		buttonQuitSfx.Play();
		buttonQuitYes.Disabled = true;
		buttonQuitYes.TextureDisabled = buttonQuitYes.TexturePressed;

		GetTree().CreateTimer(0.2).Timeout += () =>
		{
			animations.AnimationFinished += (_) =>
			{
				ChangeSceneToFile(sceneLocation, true);
			};
				
			animations.Play(ANIM_FADE_OUT);
		};
	}
	private void OnButtonQuitNo()
	{
		buttonQuitNo.Disabled = true;
		buttonQuitNo.TextureDisabled = buttonQuitNo.TexturePressed;
		buttonQuitSfx.Play(); // change sound for 'erase' noise
		GetTree().ChangeSceneToFile("res://d_scenes/game/game_puzzle.tscn");
	}
}
