#region References
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
#endregion

public class AudioManager : MonoBehaviour 
{
	#region Private Variables
	private string						_soundBankName;
	private Dictionary<string, uint> 	_soundDictionary;

	private uint						_backgroundSoundID;
	private uint						_backgroundSpeedParameterID;
	private uint						_backgroundCabinParameterID;

	private uint						_backgroundSoundtrackID;
	private uint						_backgroundSoundtrackParameter;

	private uint						_backgroundSoundStopID;
	private uint						_backgroundSoundtrackStopID;

	private uint						_backgroundSoundPlayingID;
	private uint						_backgroundSoundtrackPlayingID;
	#endregion
	
	#region Public Variables
	public static AudioManager 			audioInstance;
	#endregion
	
	#region Properties
	#endregion
	
	#region Constructors
	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);

		audioInstance = this;
	}
	
	void Start() 
	{
		_soundBankName = "Shuriken_Game";

		if(AkSoundEngine.IsInitialized() == true)
		{
			uint soundBankID;
			AkSoundEngine.LoadBank(_soundBankName, AkSoundEngine.AK_DEFAULT_POOL_ID, out soundBankID);
		}

		_backgroundSoundID = AK.EVENTS.PLAY_BACKGROUND_LOOP;
		_backgroundSoundtrackID = AK.EVENTS.PLAY_SHURIKEN_MUSIC_001;

		/*_backgroundSoundID = AK.EVENTS.PLAY_TRAIN_AMBIANCE; 
		_backgroundSpeedParameterID = AK.GAME_PARAMETERS.TRAIN_SPEED;
		_backgroundCabinParameterID = AK.GAME_PARAMETERS.TRAIN_AMBIANCE;

		_backgroundSoundtrackID = AK.EVENTS.PLAY_INTRO_OUTRO;
		_backgroundSoundtrackParameter = AK.GAME_PARAMETERS.INTRO_OUTRO;

		_backgroundSoundPlayingID = 0;
		_backgroundSoundtrackPlayingID = 0;*/

		LoadSoundDictionary();
	}
	#endregion

	#region Destructor
	void Destroy()
	{
		if(AkSoundEngine.IsInitialized() == true)
		{
			IntPtr memoryBankPtr = IntPtr.Zero;
			AkSoundEngine.UnloadBank(_soundBankName, memoryBankPtr);
		}
	}
	#endregion
	
	#region GameLoop
	void Update()
	{
	}
	#endregion
	
	#region Methods
	public void PlayBackgroundSound()
	{
		if(AkSoundEngine.IsInitialized())
		{
			_backgroundSoundPlayingID = AkSoundEngine.PostEvent(_backgroundSoundID, gameObject, (uint) AkCallbackType.AK_EnableGetMusicPlayPosition);

			PlaySoundTrack();
		}
	}

	public void PlaySoundTrack()
	{
		_backgroundSoundtrackPlayingID = AkSoundEngine.PostEvent(_backgroundSoundtrackID, gameObject, (uint) AkCallbackType.AK_EnableGetMusicPlayPosition);
	}

	public void StopBackgroundSound()
	{
		if(_backgroundSoundPlayingID != 0)
		{
			AkSoundEngine.StopPlayingID(_backgroundSoundPlayingID);

			_backgroundSoundPlayingID = 0;

			StopBackgroundSoundTrack();
		}
	}

	private void StopBackgroundSoundTrack()
	{
		if(_backgroundSoundtrackPlayingID != 0)
		{
			AkSoundEngine.StopPlayingID(_backgroundSoundtrackPlayingID);
			
			_backgroundSoundtrackPlayingID = 0;
		}
	}


	public void PlaySound(string asset)
	{
		if(AkSoundEngine.IsInitialized())
		{
			AkSoundEngine.PostEvent(_soundDictionary[asset], gameObject);
		}
	}
	#endregion

	#region Dictionary Loader
	private void LoadSoundDictionary()
	{
		_soundDictionary = new Dictionary<string, uint>();

		_soundDictionary.Add("ShurikenRelease", AK.EVENTS.PLAY_SHURIKEN_RELEASE);
		_soundDictionary.Add("Run", AK.EVENTS.PLAY_NINJA_FOOTSTEPS);
		_soundDictionary.Add("Dash", AK.EVENTS.PLAY_NINJA_DASH);
		_soundDictionary.Add("Teleport", AK.EVENTS.PLAY_NINJA_TELEPORT_DISAPPEAR);
		/*_soundDictionary.Add("", AK.EVENTS.);
		_soundDictionary.Add("", AK.EVENTS.);
		_soundDictionary.Add("", AK.EVENTS.);
		_soundDictionary.Add("", AK.EVENTS.);
		_soundDictionary.Add("", AK.EVENTS.);
		_soundDictionary.Add("", AK.EVENTS.);
		_soundDictionary.Add("", AK.EVENTS.);
		_soundDictionary.Add("", AK.EVENTS.);
		_soundDictionary.Add("", AK.EVENTS.);
		_soundDictionary.Add("", AK.EVENTS.);
		_soundDictionary.Add("", AK.EVENTS.);
		_soundDictionary.Add("", AK.EVENTS.);
		_soundDictionary.Add("", AK.EVENTS.);
		_soundDictionary.Add("", AK.EVENTS.);*/

		PlayBackgroundSound();
	}
	#endregion
}
