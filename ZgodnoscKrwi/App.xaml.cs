﻿using System.Reflection;
using ZgodnoscKrwi.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StyleMVVM;
using StyleMVVM.View;
using StyleMVVM.DependencyInjection;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Grid App template is documented at http://go.microsoft.com/fwlink/?LinkId=234226

namespace ZgodnoscKrwi
{
	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	sealed partial class App : Application
	{
		/// <summary>
		/// Initializes the singleton Application object.  This is the first line of authored code
		/// executed, and as such is the logical equivalent of main() or WinMain().
		/// </summary>
		public App()
		{
			this.InitializeComponent();
			this.Suspending += OnSuspending;
			
			CreateBootstrapper();
		}

		/// <summary>
		/// Invoked when the application is launched normally by the end user.  Other entry points
		/// will be used when the application is launched to open a specific file, to display
		/// search results, and so forth.
		/// </summary>
		/// <param name="args">Details about the launch request and process.</param>
		protected override async void OnLaunched(LaunchActivatedEventArgs args)
		{
			LaunchBootStrapper();

			// Do not repeat app initialization when already running, just ensure that
			// the window is active
			if (args.PreviousExecutionState == ApplicationExecutionState.Running)
			{
				Window.Current.Activate();
				return;
			}

			// Create a Frame to act as the navigation context and associate it with
			// a SuspensionManager key
			var rootFrame = new Frame();

			StyleMVVM.Suspension.SuspensionManager.RegisterFrame(rootFrame, "AppFrame");

			if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
			{
				// Restore the saved session state only when appropriate
				await StyleMVVM.Suspension.SuspensionManager.RestoreAsync();
			}

			if (rootFrame.Content == null)
			{
				Type navigateType = Bootstrapper.Instance.Container.LocateExportType("StartPage");

				// Could not find start page. make sure you have a page marked as [StartPage]
				if (navigateType == null)
				{
					throw new Exception("Could not find start page.");
				}

				INavigationService navigationService =
					Bootstrapper.Instance.Container.Locate<INavigationService>(rootFrame);

				if (!navigationService.Navigate(navigateType))
				{
					throw new Exception("Failed to create initial page");
				}
			}

			// Place the frame in the current Window and ensure that it is active
			Window.Current.Content = rootFrame;
			Window.Current.Activate();
		}

		/// <summary>
		/// Invoked when application execution is being suspended.  Application state is saved
		/// without knowing whether the application will be terminated or resumed with the contents
		/// of memory still intact.
		/// </summary>
		/// <param name="sender">The source of the suspend request.</param>
		/// <param name="e">Details about the suspend request.</param>
		private async void OnSuspending(object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral();
			await StyleMVVM.Suspension.SuspensionManager.SaveAsync();
			deferral.Complete();
		}

		private void CreateBootstrapper()
		{
			if (!Bootstrapper.HasInstance)
			{
				Bootstrapper newBootstrapper = new Bootstrapper();

				newBootstrapper.Container.RegisterAssembly(
					GetType().GetTypeInfo().Assembly);

				newBootstrapper.Container.RegisterAssembly(
					typeof(CSharpContainerLoader).GetTypeInfo().Assembly);

				newBootstrapper.Start(false);
			}
		}

		private void LaunchBootStrapper()
		{
			Bootstrapper.Instance.Launched();
		}
	}
}
