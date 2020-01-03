// Copyright (c) 2017 Leacme (http://leac.me). View LICENSE.md for more information.
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Humanizer;
using Leacme.Lib.RoboClue;

namespace Leacme.App.RoboClue {

	public class AppUI {

		private StackPanel rootPan = (StackPanel)Application.Current.MainWindow.Content;
		private Library lib = new Library();

		public AppUI() {

			var blur1 = App.TextBlock;
			blur1.TextAlignment = TextAlignment.Center;
			blur1.Text = "Local System Information:";

			var dg = App.DataGrid;
			dg.Height = 420;

			dg.AutoGeneratingColumn += (z, zz) => { zz.Column.Header = ((string)zz.Column.Header).Humanize(LetterCasing.Title); };
			dg.Items = lib.GetComputerInformation().Select(z => new { z.variable, z.value });

			rootPan.Children.AddRange(new List<IControl> { blur1, new Control { Height = 7 }, dg });
		}
	}
}