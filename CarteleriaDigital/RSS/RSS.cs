using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CarteleriaDigital.RSS
{
    class RSS
    {
        #region Metodos Auxiliares
            /// <summary>
            /// Obtiene la disponibilidad o no de internet
            /// </summary>
            /// <returns>Verdadero si hay disponibilidad, Falso en caso contrario</returns>
            private static bool InternetDisponible()
            {
                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                    return false;
                else
                    try
                    {
                        (new System.Net.WebClient()).OpenRead("http://www.google.com");
                        return true;
                    } 
                    catch(Exception)
                    {
                        return false;
                    }
            }

            private static TResult GetXmlNodeValue<TResult>(XmlNode pParentNode, String pChildNodeName)
            {
                if (pParentNode == null) { throw new ArgumentNullException("pParentNode"); }

                if (String.IsNullOrWhiteSpace(pChildNodeName)) { throw new ArgumentException("pChildNodeName"); }

                // Inicialmente se devuelve el valor por defecto del tipo genérico. Si es un objeto, este valor es null, en caso contrario depende del tipo.
                TResult mResult = default(TResult);

                // Tipo utilizado para la conversión final. Por defecto va a ser el mismo tipo genérico indicado.
                Type mConvertToType = typeof(TResult);

                XmlNode mChildNode = pParentNode.SelectSingleNode(pChildNodeName);

                // Si el nodo existe, entonces se obtiene el valor del texto del mismo para convertirlo al tipo genérico indicado.
                if (mChildNode != null)
                {
                    // Se comprueba si el tipo es Nullable, ya que en dicho caso se debe convertir al tipo subyacente y no directamente al Nullable.
                    if (Nullable.GetUnderlyingType(mConvertToType) != null)
                    {
                        mConvertToType = Nullable.GetUnderlyingType(mConvertToType);
                    }

                    // Se realiza la conversión del texto del nodo al tipo adecuado, ya sea el tipo genérico indicado o bien al tipo subyacente del Nullable.
                    mResult = (TResult)Convert.ChangeType(mChildNode.InnerText.Trim(), mConvertToType);
                }

                return mResult;
            }
        #endregion

        #region Metodos Principales
            /// <summary>
            /// Devuelve el Feed Rss a partir de una cadena de texto.
            /// </summary>
            /// <param name="pUrl">Cadena de texto del url de la fuente Rss</param>
            /// <returns>Lista de Items Rss</returns>
            public static List<RssItem> Feed(string pUrl) { return Feed(new Uri(pUrl)); }

            /// <summary>
            /// Devuelve el Feed Rss a partir de una Uri.
            /// </summary>
            /// <param name="pUrl">Uri que contenga el url de la fuente Rss</param>
            /// <returns></returns>
            public static List<RssItem> Feed(Uri pUrl)
            {
                if (pUrl == null) { throw new ArgumentNullException("pUrl"); }

                if (!InternetDisponible()) { throw new NotInternetAvailable("Para poder hacer el Feed es indispensable internet."); }

                try
                {
                    XmlTextReader mXmlReader = new XmlTextReader(pUrl.AbsoluteUri);

                    XmlDocument mRssXmlDocument = new XmlDocument();

                    mRssXmlDocument.Load(mXmlReader);

                    List<RssItem> mRssItems = new List<RssItem>();

                    foreach (XmlNode bRssXmlItem in mRssXmlDocument.SelectNodes("//channel/item"))
                    {
                        mRssItems.Add(new RssItem
                            (
                            GetXmlNodeValue<String>(bRssXmlItem, "title"),
                            GetXmlNodeValue<String>(bRssXmlItem, "description"),
                            GetXmlNodeValue<DateTime>(bRssXmlItem, "pubDate"),
                            new Uri(GetXmlNodeValue<String>(bRssXmlItem, "link"))
                            )
                        );
                    }

                    return mRssItems;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        #endregion
    }
}
