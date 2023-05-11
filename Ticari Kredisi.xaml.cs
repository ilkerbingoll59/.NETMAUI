namespace ödev;

public partial class Ticari_Kredisi : ContentPage
{
	public Ticari_Kredisi()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        double kredi_Tutari = double.Parse(kredi_tutari.Text);
        double faiz_Orani = double.Parse(faiz_orani.Text);
        int vade = int.Parse(vade_ay.Text);


        double brutfaiz = ((faiz_Orani + (faiz_Orani * 0.5) + (faiz_Orani * 0)) / 100);
        double taksit = ((Math.Pow(1 + brutfaiz, vade) * brutfaiz) / (Math.Pow(1 + brutfaiz, vade) - 1)) * kredi_Tutari;
        double toplam = taksit * vade;

        taksittutari.Text = taksit.ToString();
        topödeme.Text = toplam.ToString();
        topfaiz.Text = brutfaiz.ToString();
    }
}