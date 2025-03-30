using MauiAppMinhasCompras.Models;


namespace MauiAppMinhasCompras.Views;

public partial class Relatorio : ContentPage

{
	
	public Relatorio()
	{
		InitializeComponent();
       
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {

        var dataInicio = dataInicioDatePicker.Date;
        var dataFim = dataFinalDatePicker.Date;

        var filtroFinal = await SearchByTime(dataInicio, dataFim);
        ProdutosFiltrados.ItemsSource = filtroFinal;

    }

    public async Task<List<Produto>> SearchByTime(DateTime dataInicio, DateTime dataFim)
    {

        var filtroFinal = new List<Produto>();
        string sql = $"SELECT * FROM Produto WHERE DataCadastro BETWEEN {dataInicio} AND {dataFim}";

        filtroFinal = await App.Db.QueryAsync<Produto>(sql);

        return filtroFinal;
    }


}

   
