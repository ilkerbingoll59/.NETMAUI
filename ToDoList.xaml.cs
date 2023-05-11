using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ödev;

public partial class ToDoList : ContentPage
{
	public ToDoList()
	{
		InitializeComponent();

		if(File.Exists(filename))
		{
			string data = File.ReadAllText(filename);
			todos = JsonSerializer.Deserialize<ObservableCollection<ToDo>>(data);
		}

		view.ItemsSource = todos;
	}

	public ObservableCollection<ToDo> Todos => todos;

    ObservableCollection<ToDo> todos = new()
	{
		new ToDo() {todo = "Sınava Gir"}
	};

    private async void Button_Clicked(object sender, EventArgs e)
    {
		UserPage page = new UserPage() { Title="Not Ekle", AddMethod = AddNot };
		await Navigation.PushModalAsync(page);

	
    }

	public void AddNot(ToDo todo)
	{
        todos.Add(todo);

    }

    private async void EditCommand_Clicked(object sender, EventArgs e)
    {
		var but = sender as ImageButton;

		if (but != null)
		{
			var id = but.CommandParameter.ToString();
            var user = todos.Single(o => o.ID == id);

            UserPage page = new UserPage() { Title = "Notu Düzenle", User = user  };
            await Navigation.PushModalAsync(page);
        }
    }

    private async void ImageButton_Clicked_1(object sender, EventArgs e)
    {
		var but = sender as ImageButton;

		if(but != null)
		{
			var id = but.CommandParameter.ToString();
			var user = todos.Single(o => o.ID == id);

			var res = await DisplayAlert("Silmeyi onayla", $"'{user.todo}' silinsin mi?", "EVET","HAYIR");
			if (res)
				todos.Remove(user);
		}
    }

	string filename = Path.Combine(FileSystem.Current.AppDataDirectory, "data.json");
    private void Button_Clicked_1(object sender, EventArgs e)
    {
		string data = JsonSerializer.Serialize(todos);
		File.WriteAllText(filename, data);
    }
}

public class ToDo : INotifyPropertyChanged
{
    public string ID
	{
		get
		{ 
			if (id == null)
			id = Guid.NewGuid().ToString();
			return id;
		}
		set { id = value; } 
	}	
	string id,tlist;
	[JsonIgnore]
	public string todo { get => tlist; set { tlist = value; NotifyPropertyChanged(); } }

    public event PropertyChangedEventHandler PropertyChanged;

	public void NotifyPropertyChanged([CallerMemberName] string propertyName="")
	{
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}