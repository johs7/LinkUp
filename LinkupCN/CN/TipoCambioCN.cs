using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinkupCN.CN
{
    public class TipoCambioCN
    {
        private readonly string serviceUrl = "https://servicios.bcn.gob.ni/Tc_Servicio/ServicioTC.asmx";
        private readonly string soapActionMonth = "http://servicios.bcn.gob.ni/RecuperaTC_Mes";
        private readonly string soapActionDay = "http://servicios.bcn.gob.ni/RecuperaTC_Dia";

        public async Task<double> ObtenerTipoCambioDia(int year, int month, int day)
        {
            double tipoCambio = await GetExchangeRateForDayAsync(year, month, day);

            return tipoCambio;
        }
        public async Task<XDocument> ObtenerTipoCambioMes(int year, int month)
        {
            XDocument tipoCambio = await GetExchangeRatesForMonthAsync(year, month);

            return tipoCambio;
        }


        /* Este método obtiene el tipo de cambio promedio mensual para un año y mes específicos utilizando
         * una solicitud SOAP al servicio web. Devuelve un documento XML que contiene los datos del tipo de cambio. */
        public async Task<XDocument> GetExchangeRatesForMonthAsync(int year, int month)
        {
            using (HttpClient client = new HttpClient())
            {
                string soapEnvelope = $@"<?xml version=""1.0"" encoding=""utf-8""?>
        <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
            <soap:Body>
                <RecuperaTC_Mes xmlns=""http://servicios.bcn.gob.ni/"">
                    <Ano>{year}</Ano>
                    <Mes>{month}</Mes>
                </RecuperaTC_Mes>
            </soap:Body>
        </soap:Envelope>";

                StringContent content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");
                client.DefaultRequestHeaders.Add("SOAPAction", soapActionMonth);

                HttpResponseMessage response = await client.PostAsync(serviceUrl, content);
                string responseContent = await response.Content.ReadAsStringAsync();

                XDocument xDoc = XDocument.Parse(responseContent);
                return xDoc;
            }
        }

        /* Este método obtiene el tipo de cambio promedio para un día específico en un año y mes determinados utilizando una solicitud SOAP al servicio web.
         * Devuelve el valor del tipo de cambio para el día especificado. */
        public async Task<double> GetExchangeRateForDayAsync(int year, int month, int day)
        {
            using (HttpClient client = new HttpClient())
            {
                string soapEnvelope = $@"<?xml version=""1.0"" encoding=""utf-8""?>
        <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
            <soap:Body>
                <RecuperaTC_Dia xmlns=""http://servicios.bcn.gob.ni/"">
                    <Ano>{year}</Ano>
                    <Mes>{month}</Mes>
                    <Dia>{day}</Dia>
                </RecuperaTC_Dia>
            </soap:Body>
        </soap:Envelope>";

                StringContent content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");
                client.DefaultRequestHeaders.Add("SOAPAction", soapActionDay);

                HttpResponseMessage response = await client.PostAsync(serviceUrl, content);
                string responseContent = await response.Content.ReadAsStringAsync();

                XDocument xDoc = XDocument.Parse(responseContent);

                XNamespace soapNs = "http://schemas.xmlsoap.org/soap/envelope/";
                XNamespace responseNs = "http://servicios.bcn.gob.ni/";

                var responseElement = xDoc.Descendants(soapNs + "Body")
                                         .Descendants(responseNs + "RecuperaTC_DiaResponse")
                                         .FirstOrDefault();

                if (responseElement != null)
                {
                    double exchangeRate = double.Parse(responseElement.Element(responseNs + "RecuperaTC_DiaResult").Value);
                    return exchangeRate;
                }
                else
                {
                    throw new Exception("No se pudo obtener el tipo de cambio del día.");
                }
            }
        }
    }
}
