namespace ödev;

public partial class UserPage : ContentPage
{
	public UserPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (User != null )
        {
            txtNot.Text = User.todo;
        }
    }
    public bool Result { get; set; } = false;
    public ToDo User { get; set; }
    public Action<ToDo> AddMethod { get; internal set; }

    private void btnOk_Clicked(object sender, EventArgs e)
    {
        if(User == null)
        {
            User = new ToDo()
            {
                todo = txtNot.Text,
            };
        }else
        {
            User.todo = txtNot.Text;
        }

        if(AddMethod!= null)
            AddMethod(User);
        Result = true;

        Navigation.PopModalAsync();
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Result &= false;
        Navigation.PopModalAsync();
    }
}