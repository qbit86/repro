#if UNITY_ANDROID

using System;
using System.IO;
using System.Text;
using UnityEditor.Android;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Assertions;

namespace MyGame
{
	// https://docs.unity3d.com/ScriptReference/Android.IPostGenerateGradleAndroidProject.html
	// https://forum.unity.com/threads/gradle-build-error-gradle-version-2-10-is-required-current-version-is-4-0-1.499520/#post-4734422

	internal sealed class GradlePropertiesPostprocessor : IPostGenerateGradleAndroidProject
	{
		int IOrderedCallback.callbackOrder => byte.MaxValue;

		void IPostGenerateGradleAndroidProject.OnPostGenerateGradleAndroidProject(string path) =>
			EnsureJetifierIsEnabled(path);

		private static void EnsureJetifierIsEnabled(string path)
		{
			const string tag = nameof(GradlePropertiesPostprocessor) + "." + nameof(EnsureJetifierIsEnabled);

			Assert.IsNotNull(path, $"[{tag}] {nameof(path)} != null");

			string gradlePropertiesFileName = Path.Combine(path, "gradle.properties");
			var gradlePropertiesFile = new FileInfo(gradlePropertiesFileName);

			if (!gradlePropertiesFile.Exists)
			{
				CreateGradlePropertiesFileWithJetifierEnabledNoThrow(gradlePropertiesFile);
				return;
			}

			OverwriteGradlePropertiesFileWithJetifierEnabledNoThrow(gradlePropertiesFile);
		}

		private static void CreateGradlePropertiesFileWithJetifierEnabledNoThrow(FileInfo gradlePropertiesFile)
		{
			try
			{
				const string tag = nameof(GradlePropertiesPostprocessor) + "." +
					nameof(CreateGradlePropertiesFileWithJetifierEnabledNoThrow);

				Debug.Log($"[{tag}] {nameof(gradlePropertiesFile)}: {gradlePropertiesFile}");

				using (StreamWriter writer = gradlePropertiesFile.AppendText())
				{
					writer.WriteLine("android.useAndroidX=true");
					writer.WriteLine("android.enableJetifier=true");
					writer.Flush();
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
			}
		}

		private static void OverwriteGradlePropertiesFileWithJetifierEnabledNoThrow(FileInfo gradlePropertiesFile)
		{
			try
			{
				const string tag = nameof(GradlePropertiesPostprocessor) + "." +
					nameof(OverwriteGradlePropertiesFileWithJetifierEnabledNoThrow);

				Debug.Log($"[{tag}] {nameof(gradlePropertiesFile)}: {gradlePropertiesFile}");

				var sb = new StringBuilder((int)gradlePropertiesFile.Length);
				using (var reader = new StreamReader(gradlePropertiesFile.FullName, Encoding.UTF8))
				{
					while (true)
					{
						string line = reader.ReadLine();
						if (line is null)
							break;

						if (line.TrimStart().StartsWith("android.useAndroidX", StringComparison.Ordinal))
							continue;

						if (line.TrimStart().StartsWith("android.enableJetifier", StringComparison.Ordinal))
							continue;

						sb.AppendLine(line);
					}

					sb.AppendLine("android.useAndroidX=true");
					sb.AppendLine("android.enableJetifier=true");
				}

				string gradlePropertiesNewContent = sb.ToString();
				Debug.Log(
					$"[{tag}] {nameof(gradlePropertiesNewContent)}:{Environment.NewLine}{gradlePropertiesNewContent}");

				using (var writer = new StreamWriter(gradlePropertiesFile.FullName, false, Encoding.UTF8))
				{
					writer.Write(gradlePropertiesNewContent);
					writer.Flush();
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
			}
		}
	}
}

#endif
