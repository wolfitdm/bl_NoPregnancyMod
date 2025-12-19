using Den.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Mono.Security.X509.X520;
using static UnityEngine.Rendering.VolumeComponent;

namespace BitchLand//must have this namespace
{
	class bl_NoPregnancyModDoWork 
	{
		public bl_NoPregnancyModDoWork() 
		{ 
		}
		
		public void OnEnable()
		{
			Main.Instance.Player.Fertility = 0;
			Main.Instance.Player.StoryModeFertility = 0;
			enabled = true;
		}

        public void OnDisable()
        {
			Main.Instance.Player.Fertility = 1;
			Main.Instance.Player.StoryModeFertility = 0;
            enabled = false;
        }

		public void OnStart()
		{
			if (enabled)
			{
				this.OnEnable();
			} else
			{
				this.OnDisable();
			}
		}

        public static bl_NoPregnancyModDoWork Instance = new bl_NoPregnancyModDoWork();
		private bool enabled = false;
    }

	public class Mod//must have this class name
	{
		public static bl_NoPregnancyMod ThisMod;

		public static void Init() //must have this name, and MUST be static
		{
			ThisMod = Main.Instance.gameObject.AddComponent<bl_NoPregnancyMod>();
		}



		public static void EnableMod(bool value)
		{
			if(value)
			{//mod was enabled in the settings
				bl_NoPregnancyModDoWork.Instance.OnEnable();
            }
			else
			{
				bl_NoPregnancyModDoWork.Instance.OnDisable();
			}
		}
	}

	public class bl_NoPregnancyMod : MonoBehaviour
	{
		public void Start()
		{
            bl_NoPregnancyModDoWork.Instance.OnStart();
        }

	}
}

