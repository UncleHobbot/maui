using System.Linq;
using Xamarin.Forms;
using Xamarin.Platform;
using Xamarin.Platform.Core;

namespace BpmsPOC
{
	public class BPMSApp : IApp
	{
		public BPMSApp()
		{
			Platform.Init();
		}

		public IView CreateView()
		{
			var verticalStack = new VerticalStackLayout { Spacing = 5, BackgroundColor = Color.AntiqueWhite, VerticalOptions = LayoutOptions.Fill };
			var header = new HorizontalStackLayout { Spacing = 2, BackgroundColor = Color.LightGreen, VerticalOptions = LayoutOptions.Start };
			var field = new HorizontalStackLayout { Spacing = 2, VerticalOptions = LayoutOptions.CenterAndExpand };
			var footer = new HorizontalStackLayout { Spacing = 2, VerticalOptions = LayoutOptions.End };

			var btnTasks = new Button { Text = "Tasks" };
			btnTasks.Clicked += (sender, args) =>
			{
				//ClearLayout(field);
				field.Add(new Label { Text = "Task List" });
			};

			var btnLog = new Button { Text = "Log" };
			btnLog.Clicked += (sender, args) =>
			{
				//ClearLayout(field);
				var lbl = new Label { Text = "Application Log", TextColor = Color.Black };
				field.Add(lbl);
				lbl.IsVisible = false;
				lbl.IsVisible = true;
			};

			var btnForm = new Button { Text = "Form" };
			btnForm.Clicked += (sender, args) =>
			{
				//ClearLayout(field);
				field.Add(new Label { Text = "User Form" });
			};

			header.Add(btnTasks);
			header.Add(btnLog);
			header.Add(btnForm);

			var lblField = new Label { Text = "This is a field" };
			field.Add(lblField);

			var label = new Label { Text = "Powered by BPMS" };
			footer.Add(label);

			verticalStack.Add(header);
			verticalStack.Add(field);
			verticalStack.Add(footer);

			return verticalStack;
		}

		private void ClearLayout(IStackLayout l)
		{
			var cs = l.Children.ToList();
			foreach (var child in cs)
				l.Remove(child);
		}
	}
}
