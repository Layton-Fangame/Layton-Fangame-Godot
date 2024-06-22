namespace Com.LaytonCommunity.RavensCurse.Game;

// Base for puzzles, different types may add stuff like submit button/movable objects
public partial class puzzle : Ui.UiBase
{
	// Constants
	//public const string ANIM_FADE_OUT = "ui_title/fade_out";
	
	// Enums
	
	// Signal
	
	// Export variables
	// onready var puzzle_quit_popup = load("res://d_scenes/ui/ui_puzzle_quit_popup.tscn");
	[ExportGroup("Imports")]
	[Export(PropertyHint.File,"*.tscn")] private string sceneLocation;
	[Export] protected TextureButton buttonQuit;
	[Export] protected TextureButton buttonHints;
	[Export] protected TextureButton buttonMemo;
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
		// var puzzle = GetTree().GetNodesInGroup(Puzzle.GROUP).ToList<Puzzle>();
		
		while (true) {
		if (true) // replace with correctly-solved condition
		{
			buttonQuit.Disabled = true;
			buttonHints.Disabled = true;
			buttonMemo.Disabled = true;
			
			puzzleSolveCorrect.Play();
			animations.AnimationFinished += (_) =>
			{
				// go to 'correct' scene
			};
		}
		else if (false) // failure condition
		{
			puzzleSolveIncorrect.Play();
			animations.AnimationFinished += (_) =>
			{
				// go to 'incorrect' scene
			};
		}
		}
	}

	private void OnButtonQuit()
	{
		buttonQuit.Disabled = true;
		buttonQuit.TextureDisabled = buttonQuit.TexturePressed;

		GetTree().ChangeSceneToFile("res://d_scenes/game/game_puzzle_quit_popup.tscn");

		//animations.Play(ANIM_FADE_OUT);
		buttonQuitSfx.Play();
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
}
