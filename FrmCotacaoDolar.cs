using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumindoApi
{
    public partial class FrmCotacaoDolar : Form
    {
        public FrmCotacaoDolar()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string moeda = "https://api.hgbrasil.com/finance?array_limit=1&fields=only_results,USD&key=1a4b2896";
            if(cbMoeda.SelectedIndex == 0)
            {
                moeda = "https://api.hgbrasil.com/finance?array_limit=1&fields=only_results,USD&key=1a4b2896";
                lblTitle.Text = "DOLAR";
            }
            else if(cbMoeda.SelectedIndex == 1)
            {
                moeda = "https://api.hgbrasil.com/finance?array_limit=1&fields=only_results,EUR&key=1a4b2896";
                lblTitle.Text = "EURO";
            }
            
            

            string strUrl = moeda;

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(strUrl).Result;
                // solicitacao para pegar os valores da URL // breakpoint colocado

                try
                {
                    if (response.IsSuccessStatusCode) // verificar se deu certo a requisicao
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        // lemos o resultado // breakpoint colocado

                        // adicionamos a classe Market e Currency

                        Market market = JsonConvert.DeserializeObject<Market>(result);
                        // deserializando o json // adicionado em market

                        lblBuy.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", market.Currency.Buy);
                        lblSell.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", market.Currency.Sell);
                        lblVar.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:P}", market.Currency.Variation / 100);
                        // pode apenas converter para string porem aqui foi feito para embelezar ou seja colocamos o R$

                    }
                    else
                    {
                        lblBuy.Text = "-";
                        lblSell.Text = "-";
                        lblVar.Text = "-";

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


            }

        }
    }
    // video referencia https://www.youtube.com/watch?v=w_Rl0BomHWs
}
