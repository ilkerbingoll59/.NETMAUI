namespace ödev;

public partial class VucutKitleIndexi : ContentPage
{
	public VucutKitleIndexi()
	{
		InitializeComponent();
	}
    private void Button_Clicked(object sender, EventArgs e)
    {
       

        double kilo = double.Parse(kilosu.Text);
        double boy = double.Parse(boyu.Text)/100;

        double indexi = kilo / (boy * boy);

        derecesi.Text = indexi.ToString();

        if (indexi < 16)
        {
            sonuc.Text = "İleri Düzeyde Zayıf";
        }
        else if(indexi >= 16 && indexi<=16.99) {
            sonuc.Text = "Orta Düzeyde Zayıf";
        }
        else if (indexi >= 17 && indexi<=18.49 )
        {
            sonuc.Text = "Hafif Düzeyde Zayıf";
        }
        else if(indexi >= 18.50 && indexi <= 24.9)
        {
            sonuc.Text = "Normal Kilolu";
        }
        else if(indexi >=25 && indexi<=29.99)
        {
            sonuc.Text = "Hafif Şişman";
        }
        else if(indexi >=30 && indexi<=34.99)
        {
            sonuc.Text = "1. Derecede Obez";
        }
        else if(indexi>=35 && indexi<=39.99)
        {
            sonuc.Text = "2. Derecede Obez";
        }
        else if(indexi>=40)
        {
            sonuc.Text = "3. Derecede Obez";
        }
       
    }
}