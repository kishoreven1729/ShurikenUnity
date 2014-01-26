#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System;


public class AkWwiseMenu_Mac : MonoBehaviour {

	private static AkUnityPluginInstaller_Mac m_installer = new AkUnityPluginInstaller_Mac();

	private static AkUnityIntegrationBuilder_Mac m_builder = new AkUnityIntegrationBuilder_Mac();

	[MenuItem("Wwise/Install Plugins/Mac/Debug")]
	public static void InstallPlugin_Debug () {
		m_installer.InstallPluginByConfig("Debug");
	}

	[MenuItem("Wwise/Install Plugins/Mac/Profile")]
	public static void InstallPlugin_Profile () {
		m_installer.InstallPluginByConfig("Profile");
	}

	[MenuItem("Wwise/Install Plugins/Mac/Release")]
	public static void InstallPlugin_Release () {
		m_installer.InstallPluginByConfig("Release");
	}

	[MenuItem("Wwise/Rebuild Integration/Mac/Debug")]
	public static void RebuildIntegration_Debug () {
		m_builder.BuildByConfig("Debug", null);
	}

	[MenuItem("Wwise/Rebuild Integration/Mac/Profile")]
	public static void RebuildIntegration_Profile () {
		m_builder.BuildByConfig("Profile", null);
	}

	[MenuItem("Wwise/Rebuild Integration/Mac/Release")]
	public static void RebuildIntegration_Release () {
		m_builder.BuildByConfig("Release", null);
	}
}


public class AkUnityPluginInstaller_Mac : AkUnityPluginInstallerBase
{
	public AkUnityPluginInstaller_Mac()
	{
		m_platform = "Mac";
	}
}


public class AkUnityIntegrationBuilder_Mac : AkUnityIntegrationBuilderBase
{
	public AkUnityIntegrationBuilder_Mac()
	{
		m_platform = "Mac";
	}
}

#endif // #if UNITY_EDITOR