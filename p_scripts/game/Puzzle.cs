namespace Com.LaytonCommunity.RavensCurse.Game;

public partial class puzzle : Ui.UiBase
{
	// Constants
	public const string ANIM_FADE_OUT = "ui_title/fade_out";
	
	// Enums
	
	// Signal
	
	// Export variables
	onready var puzzle_quit_popup = load("res://d_scenes/ui/ui_puzzle_quit_popup.tscn")
	[ExportGroup("Imports")]
	[Export(PropertyHint.File,"*.tscn")] private string sceneLocation;
	[Export] protected TextureButton buttonQuit;
	[Export] protected TextureButton buttonHints;
	[Export] protected TextureButton buttonMemo;
	[Export] protected TextureButton buttonSubmit;
	[Export] protected AudioStreamPlayer buttonQuitSfx;
	[Export] protected VideoStreamPlayer puzzleSolveCorrect;
	[Export] protected VideoStreamPlayer puzzleSolveIncorrect;
	[Export] protected Label labelPuzzleName;
	[Export] protected Label labelPuzzleNumber;
	[Export] protected Label labelPuzzleCurrentPicarats;
	[Export] protected Label labelPuzzleMaxPicarats;
	[Export] protected Label labelPuzzleDescription;
	
	// Member Variables
	
	public override void _Ready()
	{
		base._Ready();

		buttonQuit.Pressed += OnButtonQuit;
		buttonHints.Pressed += OnButtonHints;
		buttonMemo.Pressed += OnButtonMemo;
		buttonSubmit.Pressed += OnButtonSubmit;
		// var puzzle = GetTree().GetNodesInGroup(Puzzle.GROUP).ToList<Puzzle>();
	}

	private void OnButtonQuit()
	{
		buttonQuit.Disabled = true;
		buttonQuit.TextureDisabled = buttonQuit.TexturePressed;
		
		var new_popup = puzzle_quit_popup.instance()
		new_popup.text_to_show = "Are you sure you want to quit?"
		
		buttonQuitYes.Pressed += OnButtonQuitYes;
		buttonQuitNo.Pressed += OnButtonQuitNo;

		animations.Play(ANIM_FADE_OUT);
		buttonQuitSfx.Play();
	}
	private void OnButtonQuitYes()
	{
		buttonQuitYes.Pressed -= OnButtonQuitYes;
		
		buttonQuitYes.Disabled = true;
		buttonQuitYes.TextureDisabled = buttonQuitYes.TexturePressed;

		animations.AnimationFinished += (_) =>
		{
			ChangeSceneToFile(sceneLocation, true);
		};

		animations.Play(ANIM_FADE_OUT);
	}
	private void OnButtonQuitNo()
	{
		buttonQuitNo.Disabled = true;
		buttonQuitNo.TextureDisabled = buttonQuitNo.TexturePressed;
	}

	private void OnButtonHints()
	{
		buttonHints.Disabled = true;
		buttonHints.TextureDisabled = buttonHints.TexturePressed;
	}

	private void OnButtonMemo()
	{
		buttonMemo.Disabled = true;
		buttonMemo.TextureDisabled = buttonMemo.TexturePressed;
	}

	private void OnButtonSubmit()
	{
		buttonSubmit.Disabled = true;
		buttonSubmit.TextureDisabled = buttonSubmit.TexturePressed;
		
		if (true) // replace with correctly-solved condition
		{
			puzzleSolvingCorrect.Play();
			animations.AnimationFinished += (_) =>
			{
				// go to 'correct' scene
			};
		}
		else
		{
			puzzleSolvingIncorrect.Play();
			animations.AnimationFinished += (_) =>
			{
				// go to 'incorrect' scene
			};
		}
	}
}
