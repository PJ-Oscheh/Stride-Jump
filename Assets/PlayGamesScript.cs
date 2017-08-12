using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class PlayGamesScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build();
		PlayGamesPlatform.InitializeInstance (config);
		PlayGamesPlatform.Activate ();

		//Sign in the user
		SignIn ();

	}
	void SignIn()
	{
		Social.localUser.Authenticate (success => { });
	}

	#region Achievements
	public static void UnlockAchievement (string id) {
		Social.ReportProgress (id, 100, success => { });
	}
	public static void ShowAchievementsUI() {
		Social.ShowAchievementsUI ();
	}
	#endregion /Achievements

	#region Leaderboards
	public static void AddScoreToLeaderboard(string leaderboardID, long score) {
		Social.ReportScore (score, leaderboardID, sucess => { });
		Social.ShowLeaderboardUI ();
	}
	public static void ShowLeaderboardUI() {
		Social.ShowLeaderboardUI();
	}
		
	#endregion /Leaderboards
}
